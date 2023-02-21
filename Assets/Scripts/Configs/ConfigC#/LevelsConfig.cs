using System.Collections.Generic;
using UnityEngine;
using GD.MinMaxSlider;

[CreateAssetMenu(fileName = "LevelsConfig", menuName = "Configs/LevelsConfig")]
public class LevelsConfig : ScriptableObject
{  
    /// <summary>
    /// Index = Current scene index;
    /// </summary>
    public List<LevelConfigParameters> LevelParameterConfig = new List<LevelConfigParameters>();
}

[System.Serializable]
public struct LevelConfigParameters {
    [Header("Grid")]
    public Vector2Int GameGridSize;

    [Header("Currency")]
    public int CurrencyValuePerLevel;
    public int CurrencyDropFromUnitPerLvl;
    [MinMaxSlider(0, 100)] public Vector2Int MinMaxPercentCurrencyDroppedFromUnit;

    [Header("Unit")]
    public int AllUnitsOnLevel;

    [Header("BaseOfUnit")]
    public float FriendlySpawnCooldown;
    public float EnemySpawnCooldown;
    
    [Header("Percent of AllUnitsOnEveryLine")]
    [Range(0, 100)] public int[] UnitLvl;

    [Header("The number of unit levels used, indicating the level")]
    /// <summary>
    /// количество используемых уровней юнита с указанием уровня
    /// </summary>
    public List<int> NumberOfFilledSliders;

    // public int UnitsOnLineEveryLevelCount;
}


// AllUnitsOnLevel * UnitLvl1
//---------------------------------------
//              100
    