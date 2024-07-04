using Game.Scripts.Game_Engine.Timer_Feature.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Game.Scripts.Game_Engine.Timer_Feature.Systems
{
    public struct RepeatTimer_System : IEcsRunSystem
    {
        private EcsFilterInject<Inc<Timer_Component, IsTimerExpired_Component, IsRepeatable_Component>> _filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var timerComponent = ref _filter.Pools.Inc1.Get(entity);
                var isTimerExpiredComponent = _filter.Pools.Inc2.Get(entity);
                var isRepeatableComponent = _filter.Pools.Inc3.Get(entity);

                if (isTimerExpiredComponent.Value && isRepeatableComponent.Value)
                {
                    timerComponent.Remain = timerComponent.Duration;
                }
            }
        }
    }
}