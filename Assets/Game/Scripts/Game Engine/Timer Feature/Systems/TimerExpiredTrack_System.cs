using Game.Scripts.Game_Engine.Timer_Feature.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Game.Scripts.Game_Engine.Timer_Feature.Systems
{
    public struct TimerExpiredTrack_System : IEcsRunSystem
    {
        private EcsFilterInject<Inc<Timer_Component, IsTimerExpired_Component>> _filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var timerComponent = _filter.Pools.Inc1.Get(entity);
                ref var isTimerExpiredComponent = ref _filter.Pools.Inc2.Get(entity);

                isTimerExpiredComponent.Value = timerComponent.Remain <= 0f;
            }
        }
    }
}