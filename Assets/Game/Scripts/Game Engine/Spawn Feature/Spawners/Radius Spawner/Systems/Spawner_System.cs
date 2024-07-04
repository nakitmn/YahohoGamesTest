using Game.Scripts.Game_Engine.Spawn_Feature.Spawners.Radius_Spawner.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Spawn_Feature.Spawners.Radius_Spawner.Systems
{
    public struct Spawner_System : IEcsRunSystem
    {
        private EcsFilterInject<Inc<SpawnPoint_Component, SpawnRadius_Component, SpawnCount_Component,
            SpawnPrefab_Component>> _filter;

        private EcsWorldInject _world;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var spawnPointComponent = _filter.Pools.Inc1.Get(entity);
                var spawnRadiusComponent = _filter.Pools.Inc2.Get(entity);
                ref var spawnCountComponent = ref _filter.Pools.Inc3.Get(entity);
                var spawnPrefabComponent = _filter.Pools.Inc4.Get(entity);

                for (var i = 0; i < spawnCountComponent.Value; i++)
                {
                    var spawnCircle = Random.insideUnitCircle * spawnRadiusComponent.Value;
                    var spawnPosition = spawnPointComponent.Value.position;
                    spawnPosition.x += spawnCircle.x;
                    spawnPosition.z += spawnCircle.y;

                    SpawnFeature.CreateEntity(
                        _world.Value,
                        new(
                            spawnPrefabComponent.Value,
                            spawnPosition,
                            Quaternion.identity,
                            spawnPointComponent.Value,
                            _world.Value.PackEntity(entity)
                        )
                    );
                }

                spawnCountComponent.Value = 0;
            }
        }
    }
}