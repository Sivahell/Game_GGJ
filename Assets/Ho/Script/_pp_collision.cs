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
    private void OnTriggerEnter(Collider other)//¸I¼²Åé­«Å|
    {
        hp--;
        hpBar.UpdateEnergy(hp);
        var hitPos = other.GetComponent<MobControl>().HitPlayerPos();


        hittedSfx.transform.position = hitPos;
        blood.transform.position = hitPos;
        blood.Play();
        hittedSfx.Play();
        
        if (hp <= 0)
        {
            EndFade.instance.End(EndType.Lose);
            Debug.Log("PlayerDead");
        }

    }
}
