using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
[CreateAssetMenu(fileName = "Hostile_Mob_Date", menuName = "ScriptableObjects/Hostile_Mob_Date")]
public class Hostile_Mob_Date : ScriptableObject
{
    public Hostile_Mob hostile_Mob;
}
[System.Serializable]
public class Hostile_Mob
{
    public MobType mobtype;
    public string China_Name;
    public AnimatorController China_Ani;
}
