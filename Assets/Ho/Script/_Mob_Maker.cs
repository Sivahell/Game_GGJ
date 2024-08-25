using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class _Mob_Maker : MonoBehaviour
{
    
    public GameObject mobPrefab;
    Queue<MobControl> MobControl_Queue = new();
    public Hostile_Mob_Date[] dates;
    float time;
    Dictionary<MobType, Hostile_Mob> mobDatasDictionary = new();
    private object amobControl;

    void Start()
    {
        for (int i = 0; i != 100; i++)
        {
            MobControl mobControl = Instantiate(mobPrefab).GetComponent< MobControl>();
            mobControl.Deactive();
            MobControl_Queue.Enqueue(mobControl);
        }
        foreach(Hostile_Mob_Date mob in dates)
        {
            mobDatasDictionary.Add(mob.hostile_Mob.mobtype, mob.hostile_Mob);
        }

    }

    public void Takeout(float X,float Y,float Z, MobType mobtype)
    {
        Hostile_Mob mobdata = mobDatasDictionary[mobtype];
        MobControl mobControl = MobControl_Queue.Dequeue();
        mobControl.StartMove(mobdata);
        mobControl.gameObject.transform.position = new Vector3(X, Y, Z);
        

        time = 0;
    }
    IEnumerator enumerator()
    {
        while (true)
        {
            MobControl mobControl = MobControl_Queue.Dequeue();
            gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(1f);
        }
    }
    public void IsBack(MobControl mobControl)
    {
        MobControl_Queue.Enqueue(mobControl);
        mobControl.Deactive();
    }
}
