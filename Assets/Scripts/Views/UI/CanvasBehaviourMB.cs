using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.EcsLite;
using Client;
using UnityEngine.SceneManagement;
using Cinemachine;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CanvasBehaviourMB : MonoBehaviour
{
    #region ECS
    private EcsWorld _world;
    private GameState _state;
    private EcsPool<ClickEvent> _clickPool;
    private EcsPool<InterfaceComponent> _interfacePool = default;
    private EcsPool<UpdateUIEvent> _updateUIPool = default;

    public void Init(EcsWorld world, GameState state)
    {
        world = state.EcsWorld;
        _world = world;
        _state = state;
        _clickPool = _world.GetPool<ClickEvent>();
        _interfacePool = _world.GetPool<InterfaceComponent>();
        _updateUIPool = _world.GetPool<UpdateUIEvent>();
        GetAllButtons();
        UpdateCanvas();
    }
    #endregion
    public Canvas MainCanvas;
    public GameObject InGamePanel;
    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject StorePanel;
    public GameObject SettingsPanel;
    public GameObject GeneralPanel;
    public GameObject UpgradePanel;
    public List<Button> AllButtons = new();
    //public GameObject CarsBuyPanel;
    public GameObject BiomSlider;
    public Text LevelNumberText;
    public Image NextBiomImage;
    public Color OrangeColor;
    public Image[] SliderChunks; 

    private int _cinemachinePOVCameraSpeedOff = 0;
    private float _cinemachinePOVCameraSpeedOn = 0.1f;

    public void ReloadScene()
    {
        //_state.WriteCooldowns(MinesMB.currentCoolDown, BarricadesMB.currentCoolDown);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartButton()
    {
        //ref var interfaceComponent = ref _interfacePool.Get(_state.InterfaceEntity);

        // interfaceComponent.HealthbarBehaviour.GetHolderHealhbar().gameObject.SetActive(!interfaceComponent.HealthbarBehaviour.GetHolderHealhbar().gameObject.activeSelf);
        _state.GameMode = GameMode.play;
        OpenPlayPanels();
    }

    public void OpenBeforePlayPanels()
    {
        DeactivateAllPanels();
        GeneralPanel.SetActive(true);
        InGamePanel.SetActive(true);
    }

    public void OpenPlayPanels()
    {
        DeactivateAllPanels();
        InGamePanel.SetActive(true);
    }

    public void OpenLosePanels()
    {
        ref var interfaceComponent = ref _interfacePool.Get(_state.InterfaceEntity);
        DeactivateAllPanels();
        interfaceComponent.LosePanelBehaviour.GetHolderLose().gameObject.SetActive(true);
    }

    public void OpenCloseStorePanel()
    {
        ref var interfaceComponent = ref _interfacePool.Get(_state.InterfaceEntity);
        interfaceComponent.StorePanelBehaviour.GetHolderStore().gameObject.SetActive(!interfaceComponent.StorePanelBehaviour.GetHolderStore().gameObject.activeSelf);
        GeneralPanel.SetActive(!GeneralPanel.activeSelf);
        InGamePanel.SetActive(!InGamePanel.activeSelf);
    }

    public void DeactivateAllPanels()
    {
        ref var interfaceComponent = ref _interfacePool.Get(_state.InterfaceEntity);
        InGamePanel.SetActive(false);
        interfaceComponent.WinPanelBehaviour.GetHolderWin().gameObject.SetActive(false);
        // WinPanel.SetActive(false);
        interfaceComponent.LosePanelBehaviour.GetHolderLose().gameObject.SetActive(false);
        // LosePanel.SetActive(false);
        //interfaceComponent.StorePanelBehaviour.GetHolderStore().gameObject.SetActive(false);
        // StorePanel.SetActive(false);
        //TutorialPanel.SetActive(false);
        GeneralPanel.SetActive(false);
    }

    public void CloseUpgradePanel()
    {
        UpgradePanel.SetActive(false);
    }

    public void DisableAllChilds(Transform unitTransform)
    {
        foreach (Transform child in unitTransform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void PlayClickSound()
    {
        _clickPool.Add(_world.NewEntity());
    }
    public void DisableAllButtonExceptFor(Button selectedButton)
    {
        DisableAllButtons();
        selectedButton.interactable = true;
    }

    private void GetAllButtons()
    {
        foreach (var button in transform.GetComponentsInChildren<Button>(true))
        {
            AllButtons.Add(button);
        }
    }

    public void DisableAllButtons()
    {
        foreach (var button in AllButtons)
        {
            button.interactable = false;
        }
    }
    public void EnableAllButtons()
    {
        foreach (var button in AllButtons)
        {
            button.interactable = true;
        }
        _updateUIPool.Add(_world.NewEntity());
    }

    public void UpdateCanvas()
    {
        Canvas.ForceUpdateCanvases();
    }
}
