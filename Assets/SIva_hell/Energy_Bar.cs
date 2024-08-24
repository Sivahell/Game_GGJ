using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy_Bar : MonoBehaviour
{
    public Slider slider;

    public void SetStartEnergy(int max, int SetEnergy)
    {
        slider.maxValue = max;
        slider.value = SetEnergy;
    }
    public void UpdateEnergy() { slider.value++; }
}
