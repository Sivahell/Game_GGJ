using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostile_Date : MonoBehaviour
{
    float Speed = 0.5f;
    void LateUpdate() 
    {
        this.transform.position += new Vector3(0, 0, -Speed * Time.deltaTime * 20);
    }
}
