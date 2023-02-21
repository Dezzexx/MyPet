using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using System.Collections.Generic;

namespace Client {
    sealed class DamageSystem : IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<DamageEvent>> _filterDamage = default;
        readonly EcsPoolInject<DamageEvent> _damageEventPool = default;

        readonly EcsPoolInject<UpdateUIEvent> _updateUIPool = default;
        readonly EcsPoolInject<TutorialComponent> _tutorialPool = default;
        readonly EcsPoolInject<TutorialEvent> _tutorialEvtPool = default;
        #region Universal
        readonly EcsPoolInject<Health> _healthPool = default;
        readonly EcsPoolInject<View> _viewPool = default;
        readonly EcsPoolInject<Dead> _deadPool = default; 
        readonly EcsPoolInject<InterfaceComponent> _interfaceCompPool = default; 
        readonly EcsPoolInject<CreateEffectEvent> _createEffectEventPool = default;

        readonly EcsSharedInject<GameState> _state = default;
        readonly EcsWorldInject _world = default;
#endregion
        
        private int _entityEvent = GameState.NULL_ENTITY;
        private int _entityTarget = GameState.NULL_ENTITY;  

        private Vector3 _offsetParticleVector = new Vector3(0f, 0.1f, 0f);

        public void Run (EcsSystems systems) {
            foreach (var entity in _filterDamage.Value)
            {
                _entityEvent = entity;

                ref var damageEventComp = ref _damageEventPool.Value.Get(entity);
                _entityTarget = damageEventComp.EntityTarget;

                if (_deadPool.Value.Has(_entityTarget)) {
                    DeleteEvent();
                    continue;
                }

                DeleteEvent();
            }
        }

       
        private void DamageToUnit(float damageAmount) {
            if (!_healthPool.Value.Has(_entityTarget)) return;
            ref var healthComp = ref _healthPool.Value.Get(_entityTarget);
            healthComp.CurrentAmount -= damageAmount;
            ref var viewComp = ref _viewPool.Value.Get(_entityTarget);

            if (healthComp.CurrentAmount <= 0) {
                DestroyUnit(viewComp);
            }
        }

        private void DestroyUnit(View viewComp) {
            ref var updateUIEvt = ref _updateUIPool.Value.Add(_state.Value.EcsWorld.NewEntity());

            _deadPool.Value.Add(_entityTarget);
            _viewPool.Value.Del(_entityTarget);
            _healthPool.Value.Del(_entityTarget);
            // viewComp.Transform.gameObject.SetActive(false);
        }

        private void DeleteEvent() {
            _entityTarget = GameState.NULL_ENTITY;

            _damageEventPool.Value.Del(_entityEvent);
        }

        private void CreateParticleEffect(EffectType effectType, Vector3 effectSpawnPoint) {
            _createEffectEventPool.Value.Add(_world.Value.NewEntity()).Invoke(effectType, effectSpawnPoint, Vector3.zero);
        }
    }
}