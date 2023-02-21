using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using System;
using UnityEngine;
namespace Client {
    sealed class WinCheckSystem : IEcsRunSystem 
    {
        readonly EcsSharedInject<GameState> _state = default;
        readonly EcsWorldInject _world = default;
        readonly EcsFilterInject<Inc<WinCheck>> _winFilter = default;
        readonly EcsPoolInject<WinEvent> _winPool = default;
        readonly EcsPoolInject<VibrationEvent> _vibrationPool = default;
        float waitToStart = 1f;

        public void Run (EcsSystems systems) 
        {
            foreach (var winCheckEntity in _winFilter.Value)
            {
                if (waitToStart > 0)
                    waitToStart -= Time.deltaTime;
                else
                {
                    ref var vibrationComp = ref _vibrationPool.Value.Add(_world.Value.NewEntity());
                    vibrationComp.Vibration = VibrationEvent.VibrationType.MediumImpact;

                    waitToStart = 0;
                    _state.Value.GameMode = GameMode.win;                    
                    _winPool.Value.Add(_world.Value.NewEntity());
                    _winFilter.Pools.Inc1.Del(winCheckEntity);
                }
            }
        }
    }
}