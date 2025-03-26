using UnityEngine;
using UnityEngine.Splines;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class SplinePathRenderer : MonoBehaviour
{
    public SplineContainer splineContainer;
    public int resolution = 50;//采样精度（数值越大，线越平滑）
    public float lineWidth = 0.1f;//线条宽度
    public Color lineColor = Color.white;//线条颜色

    private LineRenderer lineRenderer;

    void Start(){
        lineRenderer = GetComponent<LineRenderer>();
        DrawSplinePath();
    }

    void DrawSplinePath(){
        if (splineContainer == null){
            Debug.LogError("SplineContainer 未赋值！");
            return;
        }

        Spline spline = splineContainer.Spline;
        List<Vector3> points = new List<Vector3>();

        //按照resolution进行采样，获取平滑路径点
        for (int i = 0; i <= resolution; i++){
            float t = i / (float)resolution;//归一化插值
            Vector3 point = splineContainer.EvaluatePosition(t); //计算路径上的点
            points.Add(point);
        }

        //设置LineRenderer参数
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));//使用默认Sprite Shader
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
    }
}
