using System;
using System.Xml.Schema;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Client {
    sealed class WinSystem : IEcsRunSystem 
    {
        readonly EcsWorldInject _world = default;
        readonly EcsSharedInject<GameState> _state = default;
        readonly EcsFilterInject<Inc<WinEvent>> _winFilter = default;
        readonly EcsPoolInject<UpdateUIEvent> _updateUiEvent = default;
        readonly EcsPoolInject<InterfaceComponent> _interfacePool = default;
        readonly EcsPoolInject<TutorialEvent> _tutorialEventPool = default;

        // Text CountSoldier;
        // Text CountTanks;
        // Text CountHelicopter; 
        // Text CountTruck;
        // Text CountGigant;

        int entityEvent = GameState.NULL_ENTITY;
        public void Run (EcsSystems systems) 
        {
            foreach (var evnt in _winFilter.Value)
            {
                entityEvent = evnt;
                ref var interfaceComponent = ref _interfacePool.Value.Get(_state.Value.InterfaceEntity);
                
                
                // _state.Value.Level++;
                // var brokenCarReward = 0;
                // for (int i = 0; i < _state.Value.BrokenCarsLvl.Count; i++) {
                //     int n = _state.Value.GetNthProgression(_state.Value.BrokenCarsLvl[i]);
                //     if (_state.Value.BrokenCarsLvl[i] - 1 is not 0) {
                //         var additionalCost = (_state.Value.GameConfig.AdditionalPricePerBuying * (n - 1) * n) / 2;
                //         brokenCarReward += _state.Value.CurrentPrice1LvlCar * n + additionalCost;
                //     }
                //     else {
                //         brokenCarReward += _state.Value.CurrentPrice1LvlCar * n;
                //     }
                // }
                
                interfaceComponent.WinPanelBehaviour.StartWinEvent();
                _state.Value.PlayerResourceValue += _state.Value.LevelsConfig.LevelParameterConfig[_state.Value.SceneNumber - 1].CurrencyValuePerLevel;

                // _state.Value.PlayerResourceValue += brokenCarReward;
                ref var updateUIEvent = ref _updateUiEvent.Value.Add(_world.Value.NewEntity());

                //_state.Value.SceneNumber = index;

                //CheckTutorialStage();
                _state.Value.Save();
                DeleteEvent();
            }
        }

        private void DeleteEvent()
        {
            _winFilter.Pools.Inc1.Del(entityEvent);
        }
    }
}