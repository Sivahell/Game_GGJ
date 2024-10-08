using System.Collections;
using System.Collections.Generic;

using UnityEngine;
[CreateAssetMenu(fileName = "Mob_Data", menuName = "ScriptableObjects/Mob_Data")]
public class Mob_Data : ScriptableObject
{
    public MobData mobData;
}
[System.Serializable]
public class MobData
{
    public MobsType mobtype;
    public Sprite mobsprite;
    public float speed;
    public Vector3 colliderSize;
}

public enum MobsType
{
   Big1, Big2, Big3, Big4, Big5,Small1, Small2, Small3
}
