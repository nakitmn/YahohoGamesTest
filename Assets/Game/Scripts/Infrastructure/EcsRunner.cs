using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Infrastructure
{
    public sealed class EcsRunner : MonoBehaviour
    {
        private EcsWorld _world;
        private IEcsSystems _systems;

        [Inject]
        public void Construct(EcsWorld world, IEcsSystems systems)
        {
            _world = world;
            _systems = systems;
        }

        private void Start()
        {
            _systems.Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
            }

            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
}