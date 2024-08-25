using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flooring : MonoBehaviour
{
    public float upOffset = 0.1f;

   

    public void SetFloor()
    {
        var v3 = transform.position;
        v3.y = upOffset;
        transform.position = v3;
        Debug.Log("f");
    }
}
