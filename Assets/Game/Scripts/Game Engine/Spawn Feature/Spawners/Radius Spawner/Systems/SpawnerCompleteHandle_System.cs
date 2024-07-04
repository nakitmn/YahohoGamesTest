using Game.Scripts.Game_Engine.Spawn_Feature.Components;
using Game.Scripts.Game_Engine.Spawn_Feature.Spawners.Radius_Spawner.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Game.Scripts.Game_Engine.Spawn_Feature.Spawners.Radius_Spawner.Systems
{
    public struct SpawnerCompleteHandle_System : IEcsRunSystem
    {
        private EcsFilterInject<Inc<SpawnerContext_Component, ObjectSpawned_Component>> _filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var spawnerContextComponent = _filter.Pools.Inc1.Get(entity);
                var objectSpawnedComponent = _filter.Pools.Inc2.Get(entity);

                spawnerContextComponent.Value.OnSpawned(objectSpawnedComponent.Value);

                _filter.Pools.Inc2.Del(entity);
            }
        }
    }
}