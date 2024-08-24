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

    public void SpawnMob(Vector2 pos ,MobType mobType)
    {
        mobMaker.Takeout(pos.x, pos.y, 50, mobType);
    }

}
