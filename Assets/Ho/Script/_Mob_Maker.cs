using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class _Mob_Maker : MonoBehaviour
{
    
    public GameObject mobPrefab;
    Queue<MobControl> MobControl_Queue = new();
    public Mob_Data[] dates;
    float time;
    Dictionary<MobsType, MobData> mobDatasDictionary = new();
    private object amobControl;

    void Start()
    {
        for (int i = 0; i != 100; i++)
        {
            MobControl mobControl = Instantiate(mobPrefab).GetComponent< MobControl>();
            mobControl.Deactive();
            MobControl_Queue.Enqueue(mobControl);
        }
        foreach(Mob_Data mob in dates)
        {
            mobDatasDictionary.Add(mob.mobData.mobtype, mob.mobData);
        }

    }

    public void Takeout(float X,float Y,float Z, MobsType mobtype)
    {
        MobData mobdata = mobDatasDictionary[mobtype];
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
