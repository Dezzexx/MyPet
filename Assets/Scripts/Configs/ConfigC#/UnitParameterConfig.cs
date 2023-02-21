using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitParameterConfig", menuName = "ParametersConfig/UnitParameterConfig")]
public class UnitParameterConfig : ScriptableObject
{
    public float Health;
    public float Damage;
    public float Speed;
    public float Cooldown;
    public int UnitLvl;
    // public float StayTimeForAttack;
    // public float RateOfFire;
}
