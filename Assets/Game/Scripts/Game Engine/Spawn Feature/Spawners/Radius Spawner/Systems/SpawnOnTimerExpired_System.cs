using Game.Scripts.Game_Engine.Spawn_Feature.Components;
using Game.Scripts.Game_Engine.Spawn_Feature.Spawners.Radius_Spawner.Components;
using Game.Scripts.Game_Engine.Timer_Feature.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Game.Scripts.Game_Engine.Spawn_Feature.Spawners.Radius_Spawner.Systems
{
    public struct SpawnOnTimerExpired_System : IEcsRunSystem
    {
        private EcsFilterInject<Inc<IsTimerExpired_Component, SpawnCount_Component>> _filter;
        private EcsPoolInject<Spawn_Component> _spawnPool;
        private EcsWorldInject _world;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var isTimerExpiredComponent = _filter.Pools.Inc1.Get(entity);
                ref var spawnCountComponent = ref _filter.Pools.Inc2.Get(entity);

                if (isTimerExpiredComponent.Value)
                {
                    spawnCountComponent.Value++;
                }
            }
        }
    }
}