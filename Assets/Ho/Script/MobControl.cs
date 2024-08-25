using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobControl : MonoBehaviour
{
    float Speed = 0.5f;
    public Flooring flooring;
    public Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }
    public void StartMove(Hostile_Mob mobData)
    {
        flooring.SetFloor();
        ani.runtimeAnimatorController = mobData.China_Ani;
        gameObject.SetActive(true);
    }


    void LateUpdate() 
    {
        this.transform.position += new Vector3(0, 0, -Speed * Time.deltaTime * 20);
    }

    internal void Deactive()
    {
        gameObject.SetActive(false);
    }
}
