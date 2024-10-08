using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Blade_collision : MonoBehaviour
{
    public Energy_Bar energyBar;
    public int max_Energy = 10;
    private int energy = 0;
    public AudioSource slashSfx;
    private void Start()
    {
        energyBar.SetStartEnergy(max_Energy, energy);
    }
    private void OnTriggerEnter(Collider other)//�I���魫�|
    {
        energy++;
        other.GetComponent<MobControl>().BeHitted();
        slashSfx.Play();
        energyBar.UpdateEnergy(energy);
        if (energy >= max_Energy)
        {
            Debug.Log("�C Energy is max");
            EndFade.instance.End(EndType.Win);
        }
        BladeMove.instance.SetSpeedFactor(1-(float)energy/(float)max_Energy);
    }   
}
