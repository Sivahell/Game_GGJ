using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _pp_collision : MonoBehaviour
{
    public Energy_Bar hpBar;

    public int hp = 10;
    private void Start()
    {
        hpBar.SetStartEnergy(hp, hp);
    }
    private void OnTriggerEnter(Collider other)//¸I¼²Åé­«Å|
    {
        hp--;
        SpecialInstance.instance.mobMaker.IsBack(other.GetComponent<MobControl>());
        hpBar.UpdateEnergy(hp);
        if (hp <= 0)
        {
            Debug.Log("PlayerDead");
        }

    }
}
