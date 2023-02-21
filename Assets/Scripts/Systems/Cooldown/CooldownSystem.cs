using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client {
    sealed class CooldownSystem : IEcsRunSystem {  
        readonly EcsFilterInject<Inc<Cooldown>, Exc<Dead, BeingDraggedComponent>> _cooldownFilter = default;
        readonly EcsPoolInject<Cooldown> _cooldownPool = default;

        public void Run (EcsSystems systems) 
        {
            foreach (var cooldownEntity in _cooldownFilter.Value) {
                ref var cooldownComp = ref _cooldownPool.Value.Get(cooldownEntity);
                cooldownComp.CooldownTimer -= Time.deltaTime;

                if (cooldownComp.CooldownTimer <= 0) _cooldownPool.Value.Del(cooldownEntity);
            }
        } 
    }
}