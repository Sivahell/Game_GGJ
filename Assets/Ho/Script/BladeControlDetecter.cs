using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeControlDetecter : MonoBehaviour
{
    public static BladeControlDetecter instance;

    public Transform bladeTop;
    public Transform bladeBottom;
   
    public int buffer = 10;
    public float clickPointDistFormTop;



    private void Awake()
    {
        instance = this;
    }




    public bool CheckTouched(Vector2 clickPoint)
    {

        var pa = Camera.main.WorldToScreenPoint(bladeTop.position);
        var pb = Camera.main.WorldToScreenPoint(bladeBottom.position);
        
        float distA = Vector2.Distance(pa, pb);
        float distb = Vector2.Distance(pa, clickPoint);
        float distc = Vector2.Distance(pb, clickPoint);
       
        clickPointDistFormTop = distb;
        float s = (distA + distb + distc) / 2;
       float dist=2 * Mathf.Sqrt(s * (s - distA) * (s - distb) * (s - distc)) / distA;
        return dist<buffer;
    }

    internal float RotateWay(Vector2 way)
    {
        var pa = Camera.main.WorldToScreenPoint(bladeTop.position);
        var pb = Camera.main.WorldToScreenPoint(bladeBottom.position);
        var angle = -Mathf.Sign(Vector2.SignedAngle(way.normalized, (pb - pa).normalized));
        Debug.Log(angle);
        return angle;
    }

    public Vector2 PointSticked()
    {
        var pa = Camera.main.WorldToScreenPoint(bladeTop.position);
        var pb = Camera.main.WorldToScreenPoint(bladeBottom.position);
       // Debug.Log(pa + (pa - pb).normalized * clickPointDistFormTop);
        return pa+(pb- pa).normalized * clickPointDistFormTop;
    }

    internal float BladeRotat(Vector2 way)
    {
        var pa = Camera.main.WorldToScreenPoint(bladeTop.position);
        var pb = Camera.main.WorldToScreenPoint(bladeBottom.position);
        var signAngle = Vector2.Angle(way.normalized, (pb - pa).normalized);
        float angle = Mathf.Abs(signAngle);
        Debug.Log("A" + (angle - 90));
        
        return angle;
    }

}
