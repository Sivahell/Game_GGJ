using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _pp_collision : MonoBehaviour
{
    public Energy_Bar hpBar;
    public ParticleSystem blood;
    public int hp = 10;
    public AudioSource hittedSfx;
    private void Start()
    {
        hpBar.SetStartEnergy(hp, hp);
    }
    private void OnTriggerEnter(Collider other)//�I���魫�|
    {
        hp--;
        var hitPos = other.GetComponent<MobControl>().HitPlayerPos();


        hittedSfx.transform.position = hitPos;
        blood.transform.position = hitPos;
        blood.Play();
        hittedSfx.Play();
        hpBar.UpdateEnergy(hp);
        if (hp <= 0)
        {
            Debug.Log("PlayerDead");
        }

    }
}
