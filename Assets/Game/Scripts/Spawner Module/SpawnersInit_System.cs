using Game.Scripts.Game_Engine.Spawn_Feature;
using Game.Scripts.Game_Engine.Timer_Feature;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Game.Scripts.Spawner_Module
{
    public struct SpawnersInit_System : IEcsInitSystem
    {
        private EcsWorldInject _world;

        private readonly SpawnerContext[] _spawners;

        public SpawnersInit_System(SpawnerContext[] spawners) : this()
        {
            _spawners = spawners;
        }

        public void Init(IEcsSystems systems)
        {
            for (var i = 0; i < _spawners.Length; i++)
            {
                var spawnerContext = _spawners[i];

                var entity = SpawnerFeature.CreateEntity(
                    _world.Value,
                    new(
                        spawnerContext.Prefab,
                        spawnerContext.SpawnPoint,
                        spawnerContext.Radius
                    )
                );

                spawnerContext.Compose(_world.Value.PackEntity(entity));

                TimerFeature.InitEntity(entity, _world.Value, 
                    new(spawnerContext.SpawnDelay, true));
            }
        }
    }
}