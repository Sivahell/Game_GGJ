using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _pp_collision : MonoBehaviour
{
    public Energy_Bar hpBar;
    public ParticleSystem blood;
    public int hp = 10;
    private void Start()
    {
        hpBar.SetStartEnergy(hp, hp);
    }
    private void OnTriggerEnter(Collider other)//¸I¼²Åé­«Å|
    {
        hp--;
        var hitPos = other.GetComponent<MobControl>().HitPlayerPos();

       var point= Camera.main.WorldToScreenPoint(hitPos);


        blood.transform.position = hitPos;
        blood.Play();
        hpBar.UpdateEnergy(hp);
        if (hp <= 0)
        {
            Debug.Log("PlayerDead");
        }

    }
}
