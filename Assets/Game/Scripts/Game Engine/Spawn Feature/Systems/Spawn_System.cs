using Game.Scripts.Game_Engine.Spawn_Feature.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Zenject;

namespace Game.Scripts.Game_Engine.Spawn_Feature.Systems
{
    public struct Spawn_System : IEcsRunSystem
    {
        private EcsFilterInject<Inc<Spawn_Component>> _filter;
        private EcsPoolInject<ObjectSpawned_Component> _spawnedPool;
        private EcsWorldInject _world;

        private readonly DiContainer _diContainer;

        public Spawn_System(DiContainer diContainer) : this()
        {
            _diContainer = diContainer;
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var spawnComponent = _filter.Pools.Inc1.Get(entity);

                var instantiatedPrefab = _diContainer.InstantiatePrefab(
                    spawnComponent.Prefab,
                    spawnComponent.Position,
                    spawnComponent.Rotation,
                    spawnComponent.Parent
                );

                if (spawnComponent.CallbackEntity.Unpack(_world.Value,out var unpackedEntity))
                {
                    _spawnedPool.Value.Add(unpackedEntity).Value = instantiatedPrefab;
                }

                _world.Value.DelEntity(entity);
            }
        }
    }
}