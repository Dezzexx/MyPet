using UnityEngine;
using GD.MinMaxSlider;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
public class GameConfig : ScriptableObject
{
    [Header("GameGrid")]
    public Vector3 GridCellSize;
    public float GameGridSpaceSize;
    public int MaximumBuildingLines;

    [Header("Other")]
    public int CarsBuyButtonsLevel;
    public int MaximumUnitsOnLine;
    //[Space]

    [Header("Mines")]
    public int MinesCost;
    public int MaximumMines; 
    public float MinesCooldown; 

    [Header("Barricades")]
    public int BarricadesCost;
    public int MaximumBarricades;
    public float BarricadesCoolDown;

    [Header("Turret")]
    public int TurretsSpawnLevel;
    public float TurretCooldown;
    public int ShootsCount;
    public float BaseStartCooldown;

    [Header("Unit")]
    public float ImmortalityUnitTimer;
    public float NoSpawnDistanceToBase;

    [Header("Currency")]
    // [MinMaxSlider(0, 100)] public Vector2Int MinMaxPercentCurrencyDroppedFromUnit;
    public int AdditionalPricePerBuying;
}
