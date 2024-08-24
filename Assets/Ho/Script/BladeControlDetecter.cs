using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeControlDetecter : MonoBehaviour
{
    public static BladeControlDetecter instance;

    public Transform bladeTop;
    public Transform bladeBottom;
    public int buffer = 10;

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
        float s = (distA + distb + distc) / 2;
        Debug.Log(2 * Mathf.Sqrt(s * (s - distA) * (s - distb) * (s - distc)) / distA);
        return false;
    }

}
