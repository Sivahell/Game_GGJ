using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class BladeMove : MonoBehaviour
{
    public static BladeMove instance;

    public Transform bladeBody;
    public float overFactor = 1;
    public float overDistance = 100;
    public float overForce = 100;
    public float normalforce = 1;
    public float normalMaxSpeed = 1;
    public float overMaxSpeed = 1;
    public float rotateSpeed = 1;
    public float bladeRotateSpeed = 1;
    public float bladeRotateLimit = 1;
    public float slowFactor = 100f;
    private Vector3 velocity;
    private Vector2 movingWay;
    private Vector2 _tagetPoint;
    Coroutine moveCoro;
    Coroutine accCoro;
    bool pulling = false;
    public Bounds bounds;
    Vector3 pos => transform.position;
    private void OnEnable()
    {
        MouseInputManager.instance.OnClick += StartMove;
        MouseInputManager.instance.OnHold += UpdatePoint;
        MouseInputManager.instance.OnCancel += StopAcclerate;

    }
    private void OnDisable()
    {
        MouseInputManager.instance.OnClick -= StartMove;
        MouseInputManager.instance.OnHold -= UpdatePoint;
        MouseInputManager.instance.OnCancel -= StopAcclerate;
    }


    private void Awake()
    {
        instance = this;
    }

    public void StartMove(Vector2 v2)
    {

        if (moveCoro == null)
        {
            moveCoro = StartCoroutine(Move());
        }
        accCoro = StartCoroutine(Acc());
        pulling = true;
    }

    public IEnumerator Move()
    {
        Debug.Log("Start");
        while (InBoarder())
        {
            yield return null;
            if (!pulling)
            {
                if (velocity.magnitude > 1)
                {
                    Debug.Log("dec");
                    velocity -= (Vector3)velocity.normalized * slowFactor * Time.deltaTime;
                }
                else
                    velocity = Vector3.zero;
            }




            float lr = BladeControlDetecter.instance.RotateWay(movingWay);
            float yRotate = 90 * lr;
            bladeBody.localRotation = Quaternion.RotateTowards(bladeBody.localRotation, Quaternion.Euler(new Vector3(0, yRotate, 0)), (rotateSpeed + overFactor * rotateSpeed) * Time.deltaTime);


            transform.position += velocity * Time.deltaTime;


            float zRotate = Vector2.SignedAngle(movingWay, Vector2.up);
            float zxAngle = Vector2.SignedAngle(Vector2.right, movingWay);
            if (zxAngle < 0)
                zRotate += 180;



            if (zRotate < bladeRotateLimit || zRotate > -bladeRotateLimit)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 0, zRotate)), bladeRotateSpeed * Time.deltaTime);


        }

    }

   

    internal void SetSpeedFactor(float v)
    {
        overFactor = v;
    }

    private Vector2 PullForce()
    {
        return movingWay.normalized * (normalforce + overFactor * overForce);
    }


    IEnumerator Acc()
    {
        while (true)
        {


            var startPoint = BladeControlDetecter.instance.PointSticked();
            movingWay = _tagetPoint - startPoint;
            velocity += (Vector3)PullForce() * Time.deltaTime;
            if (velocity.magnitude > (normalMaxSpeed + overFactor * overMaxSpeed))
            {
                velocity = velocity.normalized * (normalMaxSpeed + overFactor * overMaxSpeed);
            }

            yield return null;
        }

    }

    private void StopAcclerate(Vector2 mousePos)
    {
        pulling = false;
        if (accCoro != null)
            StopCoroutine(accCoro);
        accCoro = null;
    }

    private void UpdatePoint(Vector2 mousePos)
    {
        _tagetPoint = mousePos;
    }


    private bool InBoarder()
    {
        return bounds.Contains(transform.position);
        
    }
}



