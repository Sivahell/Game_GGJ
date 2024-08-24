using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class BladeMove : MonoBehaviour
{
    public static BladeMove instance;

    public Transform bladeBody;
    public float maxSpeed = 100;
    public float normalSpeed = 1;
    public float rotateSpeed = 1;
    public float bladeRotateSpeed = 1;
    private float xRotote => bladeBody.rotation.eulerAngles.x;
    private void Awake()
    {
        instance = this;
    }

    public void MoveTo(Vector2 tagetPoint)
    {
      
        var startPoint = BladeControlDetecter.instance.PointSticked();
        Vector2 way = tagetPoint - startPoint;
        float lr = BladeControlDetecter.instance.RotateWay(way);
        float yRotate = 90* lr;
        bladeBody.rotation = Quaternion.RotateTowards(bladeBody.rotation,Quaternion.Euler(new Vector3(xRotote, yRotate, 0)), rotateSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3)way, normalSpeed * Time.deltaTime);

        float zRotate = BladeControlDetecter.instance.BladeRotat(way);
   
        
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 0, -zRotate)), bladeRotateSpeed * Time.deltaTime);

    }
}



