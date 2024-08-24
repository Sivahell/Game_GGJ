using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialInstance : MonoBehaviour
{
    public static SpecialInstance instance;
    public Hostile_Mob_Maker mobMaker;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(MobsTest());
    }

    private IEnumerator MobsTest()
    {
        while(true)
        {
            SpawnMob(MobType.Aas);
            yield return new WaitForSeconds(1);
        }
    }

    public void SpawnMob(MobType mobType)
    {
        float xpos=Random.Range(-1, 1);
        float ypos = Random.Range(1.5f, 2.5f);
        mobMaker.Takeout(xpos, ypos, 20, mobType);
    }


}
