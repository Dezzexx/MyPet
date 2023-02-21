using Client;
using Leopotam.EcsLite;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanelBehaviourMB : MonoBehaviour
{
    public GameObject TutorialPanel;
    public Text TutorialText;
    public RectTransform MineRect, BarricadeRect, HandPointerRect, BuyCarsPanel;
    public Button PlayButton, BuyCar1Button, UpgradeOkButton, NextButton;
    public Button[] BuyCarButtons;
    private List<int> ValidStages = new();

    #region ECS
    private EcsWorld _world;
    private GameState _state;
    private EcsPool<TutorialEvent> _tutorialEventPool = default;
    private EcsPool<TutorialComponent> _tutorialPool = default;
    public void Init(EcsWorld world, GameState state)
    {
        world = state.EcsWorld;
        _world = world;
        _state = state;
        _tutorialEventPool = _world.GetPool<TutorialEvent>();
        _tutorialPool = _world.GetPool<TutorialComponent>();
        InitializeValidStages();
    }

    private void InitializeValidStages()
    {
        ValidStages.Clear();
        ValidStages.Add((int)TutorialStage.LVL1_Buy_Car);
        ValidStages.Add((int)TutorialStage.LVL1_Click_OK);
        ValidStages.Add((int)TutorialStage.LVL1_Click_Play);
        ValidStages.Add((int)TutorialStage.LVL1_Click_Next);
        ValidStages.Add((int)TutorialStage.LVL2_Buy_Car_1);
        ValidStages.Add((int)TutorialStage.LVL2_Click_OK_1);
        ValidStages.Add((int)TutorialStage.LVL2_Buy_Car_2);
        ValidStages.Add((int)TutorialStage.LVL2_Click_Play_1);
        ValidStages.Add((int)TutorialStage.LVL2_Buy_Car_3);
        ValidStages.Add((int)TutorialStage.End);
    }
    #endregion

    public void NextTutorialStage(bool save)
    {
        Debug.Log(_tutorialEventPool.Has(_state.TutorialEntity));
        if (_tutorialPool.Has(_state.TutorialEntity) && ValidStages.Contains(_state.TutorialStage))
        {
            _state.TutorialStage++;
            if (_state.TutorialStage != (int)TutorialStage.LVL1_Click_Next)
            {
                _tutorialEventPool.Add(_world.NewEntity());
            }
            if (save) { _state.Save(); }
        }
    }
}
