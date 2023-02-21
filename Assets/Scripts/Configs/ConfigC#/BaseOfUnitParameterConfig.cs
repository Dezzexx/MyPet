using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD.MinMaxSlider;

[CreateAssetMenu(fileName = "BaseOfUnitParameterConfig", menuName = "ParametersConfig/BaseOfUnitParameterConfig")]
public class BaseOfUnitParameterConfig : ScriptableObject
{
    public float Health;
    public float ShootDamage;
    // public float RideDamage;
    public float Speed;
    public float UnitSpawnCooldown;
    public float RateOfFire;
    public int BaseOfUnitLvl;
    // public int ReturnedResourceAmount;
    [MinMaxSlider(0, 15)] public Vector2Int RideKillEnemyUnitValue;
}
