using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialInstance : MonoBehaviour
{
    public static SpecialInstance instance;
    public _Mob_Maker mobMaker;
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
            SpawnMob((MobsType)Random.Range(0,8));
            yield return new WaitForSeconds(2);
        }
    }

    public void SpawnMob(MobsType mobType)
    {
        float xpos=Random.Range(-2.5f, 2.5f);
        float ypos = Random.Range(0.2f, 2.3f);
        mobMaker.Takeout(xpos, ypos, 30, mobType);
    }


}
