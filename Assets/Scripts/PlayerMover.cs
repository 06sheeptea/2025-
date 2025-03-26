using UnityEngine;
using UnityEngine.Splines;
using System.Collections;
using System.Collections.Generic;

public class PlayerMover : MonoBehaviour{
    public SplineContainer splineContainer; //绑定棋盘路径
    public int currentIndex = 19; //当前节点的索引
    private List<BezierKnot> knots; //存储spline节点

    public float speed = 6f; //角色移动速度
    public float stepPause = 0.4f; //角色每走一步的停顿时间
    private int stepsToMove = 0; //需要移动的步数
    private Vector3 lastPos; //记录玩家上一次的位置

    public bool isMove; //表示玩家是否在棋盘中移动

    private void Start() {
        lastPos = transform.position;
        knots = new List<BezierKnot>(splineContainer.Spline.Knots);
        transform.position = knots[currentIndex].Position;
    }

    public void Move(int steps){
        isMove = true;
        stepsToMove = steps;
        StartCoroutine(MoveAlongSpline());
    }

    //实现角色沿路径移动
    private IEnumerator MoveAlongSpline(){
        for (int i = 0; i < stepsToMove; i++){
            currentIndex = (currentIndex + 1) % knots.Count;
            Vector3 targetPosition = knots[currentIndex].Position;

            //实现角色转向
            FlipPlayerDirection(targetPosition);

            while(Vector2.Distance(targetPosition,transform.position) > 0.01f){
                Debug.Log("MoveTowardsTarget!");
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }

            //实现走一步停顿一会
            yield return new WaitForSeconds(stepPause);

        }
        isMove = false;
    }

    private void FlipPlayerDirection(Vector3 newPos){
        Vector3 movementDirection = newPos - lastPos;
        // Debug.Log(movementDirection.x);
        //只在左右方向翻转
        if (movementDirection.x < 0){
            transform.localScale = new Vector3(1, 1, 1);
        }else if (movementDirection.x > 0){
            transform.localScale = new Vector3(-1, 1, 1);
        }

        lastPos = newPos;
    }
}
