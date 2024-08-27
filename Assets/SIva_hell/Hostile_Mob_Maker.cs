using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostile_Mob_Maker : MonoBehaviour
{
    private float Random_X_Min = -5, Random_X_Max = 6, Random_Z_Min = -5, Random_Z_Max = 6;
    public GameObject _Hostile_Object;
    Queue<GameObject> Hostile_Object_Queue = new();
    public Hostile_Mob_Date[] dates;
    float time;
    Dictionary<MobType, Hostile_Mob> mobDatasDictionary = new();



    void Start()
    {
        for (int i = 0; i != 100; i++)
        {
            GameObject gameObject = Instantiate(_Hostile_Object);
            gameObject.SetActive(false);
            Hostile_Object_Queue.Enqueue(gameObject);
        }
        foreach(Hostile_Mob_Date mob in dates)
        {
            mobDatasDictionary.Add(mob.hostile_Mob.mobtype, mob.hostile_Mob);
        }

    }
    //private void Update()
    //{
    //    if (time >= 1f)
    //        Takeout(Random.Range(Random_X_Min, Random_X_Max), this.transform.position.y, Random.Range(Random_Z_Min, Random_Z_Max), MobType.Aas);
    //    else time += Time.deltaTime;
    //}
    public void Takeout(float X,float Y,float Z, MobType mobtype)
    {
        Hostile_Mob mobdata = mobDatasDictionary[mobtype];
        GameObject gameObject = Hostile_Object_Queue.Dequeue();
        gameObject.SetActive(true);
        gameObject.transform.position = new Vector3(X, Y, Z);
        gameObject.name = mobdata.China_Name;
        //gameObject.GetComponent<Animator>().runtimeAnimatorController = mobdata.China_Ani;
        time = 0;
    }
    IEnumerator enumerator()
    {
        while (true)
        {
            GameObject gameObject = Hostile_Object_Queue.Dequeue();
            gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(1f);
        }
    }
    public void IsBack(GameObject Object)
    {
        Hostile_Object_Queue.Enqueue(Object);
        Object.SetActive(false);
    }
}
public enum MobType 
{
    Aas,
    ba,
    GG,
}
//new(Random.Range(Random_X_Min, Random_X_Max), this.transform.position.y, Random.Range(Random_Z_Min, Random_Z_Max))