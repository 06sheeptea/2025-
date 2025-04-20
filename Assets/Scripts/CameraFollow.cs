using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public DiceRoller diceRoller;
    public Transform[] targets;//当前需要跟随的目标
    public float smoothSpeed = 5f;//相机平滑速度
    public Vector3 offset = new Vector3(0, 0, -10);//相机相对于目标的位置偏移

    void LateUpdate(){
        // if (target == null) return;
        Vector3 desiredPosition = targets[diceRoller.round].position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

    // public void SetTarget(Transform newTarget){
    //     target = newTarget;
    // }
}
