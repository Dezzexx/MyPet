
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.EcsLite;
using Client;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class InGamePanelBehaviourMB : MonoBehaviour
{
    #region ECS
    private EcsWorld _world;
    private GameState _state;
    private EcsPool<SpawnEvent> _spawnEventPool = default;
    private EcsPool<UpdateUIEvent> _updateUIEventPool = default;

    public void Init(EcsWorld world, GameState state)
    {
        world = state.EcsWorld;
        _world = world;
        _state = state;
        _spawnEventPool = _world.GetPool<SpawnEvent>();
        _updateUIEventPool = _world.GetPool<UpdateUIEvent>();
        UpdateMoneyValue(_state.PlayerResourceValue);
    }
    #endregion

    [SerializeField] private Text _resourceAmount;
    //[SerializeField] private RectTransform ContentRectTransform;
    //[SerializeField] public ScrollRect ScrollRect, CarsScrollRect;
    private bool _init = false;
    private float _height = 0f;

    public Text ResourceText { get { return _resourceAmount; } set { _resourceAmount = value; } }

    public void UpdateMoneyValue(int value)
    {
        _updateUIEventPool.Add(_state.EcsWorld.NewEntity());
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
