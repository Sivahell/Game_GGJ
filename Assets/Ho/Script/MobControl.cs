using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobControl : MonoBehaviour
{
    public float speed = 0.5f;
    private float _speed = 0;
    public Flooring flooring;
    public SpriteRenderer sp;
    public SpriteRenderer sd;
    public ParticleSystem slash;
    public ParticleSystem smoke;
    public BoxCollider col;
    //animator sss;
    public void StartMove(MobData mobData)
    {
        col.enabled = true;
        //animator.runtime~~~=mobData.animtrctr;
        _speed = mobData.speed;
        flooring.SetFloor();

        sp.sprite = mobData.mobsprite;
        sd.sprite = mobData.mobsprite;
        col.size = mobData.colliderSize;
        gameObject.SetActive(true);
    }

    internal void BeHitted()
    {
        _speed = 0;
        slash.Play();
        col.enabled = false;

        LeanTween.value(1, 0, 0.8f).setOnUpdate((float val) =>
        {
            sp.color = new Color(1, 1, 1, val);
            sd.color = new Color(0, 0, 0, val);
        });
        LeanTween.delayedCall(0.2f, () => smoke.Play());
        LeanTween.delayedCall(1f, () => SpecialInstance.instance.mobMaker.IsBack(this));
    }


    internal Vector3 HitPlayerPos()
    {
        var pos= transform.position;
        col.enabled = false;
        LeanTween.delayedCall(1f, () =>
        {
            _speed = 0;
            SpecialInstance.instance.mobMaker.IsBack(this);
        });
        return pos;
    }


    void LateUpdate()
    {
        this.transform.position += new Vector3(0, 0, -_speed * Time.deltaTime);
    }

    internal void Deactive()
    {
        gameObject.SetActive(false);
    }
}
