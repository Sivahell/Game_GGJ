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
    public float bladeRotateLimit = 1;

    private void Awake()
    {
        instance = this;
    }

    public void MoveTo(Vector2 tagetPoint)
    {
        var startPoint = BladeControlDetecter.instance.PointSticked();
        if (Vector2.Distance(tagetPoint, startPoint) < 10f)
            return;

        Vector2 way = tagetPoint - startPoint;
        float lr = BladeControlDetecter.instance.RotateWay(way);
        float yRotate = 90 * lr;
        bladeBody.localRotation = Quaternion.RotateTowards(bladeBody.localRotation, Quaternion.Euler(new Vector3(0, yRotate, 0)), rotateSpeed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3)way, normalSpeed * Time.deltaTime);

        float zRotate = Vector2.SignedAngle(way, Vector2.up);
        float zxAngle = Vector2.SignedAngle(Vector2.right, way);
        if (zxAngle < 0)
            zRotate += 180;


        Debug.Log(zRotate);
        if (zRotate < bladeRotateLimit || zRotate > -bladeRotateLimit)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 0, zRotate)), bladeRotateSpeed * Time.deltaTime);

    }
}



