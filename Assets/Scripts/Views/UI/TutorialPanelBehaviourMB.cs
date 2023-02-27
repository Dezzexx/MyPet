using Client;
using Leopotam.EcsLite;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanelBehaviourMB : MonoBehaviour
{
    #region ECS
    private EcsWorld _world;
    private GameState _state;

    public void Init(EcsWorld world, GameState state)
    {
        world = state.EcsWorld;
        _world = world;
        _state = state;
    }
    #endregion

}
