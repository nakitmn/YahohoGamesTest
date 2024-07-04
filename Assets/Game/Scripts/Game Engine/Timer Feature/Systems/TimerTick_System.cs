using Game.Scripts.Game_Engine.Timer_Feature.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Timer_Feature.Systems
{
    public struct TimerTick_System : IEcsRunSystem
    {
        private EcsFilterInject<Inc<Timer_Component>> _filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var timerComponent = ref _filter.Pools.Inc1.Get(entity);

                timerComponent.Remain = Mathf.Max(0f, timerComponent.Remain - Time.unscaledDeltaTime);
            }
        }
    }
}