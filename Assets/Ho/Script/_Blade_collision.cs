using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Blade_collision : MonoBehaviour
{
    public Energy_Bar energyBar;
    public int max_Energy = 10;
    private int energy = 0;
    private void Start()
    {
        energyBar.SetStartEnergy(max_Energy, energy);
    }
    private void OnTriggerEnter(Collider other)//�I���魫�|
    {
        energy++;
        other.GetComponent<MobControl>().BeHitted();
      
        energyBar.UpdateEnergy(energy);
        if (energy >= 10)
        {
            Debug.Log("�C Energy is max");
        }
        BladeMove.instance.SetSpeedFactor(1-(float)energy/(float)max_Energy);
    }   
}
