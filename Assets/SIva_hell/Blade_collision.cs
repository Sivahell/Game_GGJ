using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade_collision : MonoBehaviour
{
    public GameObject[] Energy_GameObject = new GameObject[2];
    private readonly int Max_Energy = 10, set_Energy = 0;
    public GameObject Hostile_Mob_Maker;
    private void Start()
    {
        for (int i = 0; i < Energy_GameObject.Length; i++) Energy_GameObject[i].GetComponent<Energy_Bar>().SetStartEnergy(Max_Energy, set_Energy);
    }
    private void OnTriggerEnter(Collider other)//碰撞體重疊
    {
        int i1;
        if (other.transform.position.z >= -6) i1 = 0;
        else i1 = 1;
        if (Energy_GameObject[i1].GetComponent<Energy_Bar>().slider.value < 10)
        {
            Energy_GameObject[i1].GetComponent<Energy_Bar>().UpdateEnergy();
            Hostile_Mob_Maker.GetComponent<Hostile_Mob_Maker>().IsBack(other.gameObject);
            string Ass = i1 == 0 ? "劍擊中" : "持有者被擊中";
            Debug.Log(Ass);
        }
        else
        {
            Hostile_Mob_Maker.GetComponent<Hostile_Mob_Maker>().IsBack(other.gameObject);
            string Ass = i1 == 0 ? "劍 Energy is max" : "持有者 is Die";
            Debug.Log(Ass);
        }
        //Destroy(other.gameObject);
    }
}
