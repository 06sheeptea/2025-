using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineNodesInit : MonoBehaviour
{
    [System.Serializable]
    public class SplineNodeData{
        public Sprite sprite; //该节点的图像
        public string type; //该节点的类型
    }

    public SplineContainer splineContainer;
    private List<BezierKnot> knots; //存储spline节点
    public GameObject nodePrefab; //用来实例化图像的预制体
    public List<SplineNodeData> nodeDataList; //存储每个节点的信息

    private List<GameObject> nodeObjects = new List<GameObject>(); //存储生成的节点对象

    private void Start() {
        NodeInit();
    }

    private void NodeInit(){
        knots = new List<BezierKnot>(splineContainer.Spline.Knots);
        for (int i = 0;i < knots.Count;i++){
            GameObject nodeObj = Instantiate(nodePrefab,knots[i].Position,Quaternion.identity, transform);
            SpriteRenderer spriteRenderer = nodeObj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && i < nodeDataList.Count){
                spriteRenderer.sprite = nodeDataList[i].sprite;
            }
            nodeObjects.Add(nodeObj);
        }
    }
}
