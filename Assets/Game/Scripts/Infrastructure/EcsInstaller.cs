using Game.Scripts.Game_Engine.Item_Stack_Feature.Stack;
using Game.Scripts.Game_Engine.Movement_Feature;
using Game.Scripts.Game_Engine.Movement_Feature.Systems;
using Game.Scripts.Game_Engine.Rotation_Feature.Systems;
using Game.Scripts.Player_Module;
using Game.Scripts.Player_Module.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Zenject;

namespace Game.Scripts.Infrastructure
{
    public sealed class EcsInstaller : MonoInstaller
    {
        private EcsWorld _world;
        private IEcsSystems _systems;

        public override void InstallBindings()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            
            Container.Bind<EcsWorld>()
                .FromInstance(_world)
                .AsSingle();
        }

        public override void Start()
        {
            var initSystems = Container.Resolve<IEcsInitSystem[]>();

            foreach (var initSystem in initSystems)
            {
                _systems.Add(initSystem);
            }
            
            _systems
                .Add(Create<TransformMove_System>())
                .Add(Create<CurrentSpeedDetect_System>())
                .Add(Create<IsMovingDetect_System>())
                .Add(Create<TransformRotate_System>())
                .Add(Create<FreeSpaceCounter_System>())
                .Add(Create<TriggeredItemsDetect_System>())
                .Add(Create<PushTriggeredItemsToStack_System>())
                .Add(Create<AddItemsToStack_System>())
                .Add(Create<PlayerMove_System>())
                .Add(Create<PlayerRotate_System>())
                .Add(Create<PlayerAnimator_System>())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                .Inject()
                .Init();
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

        private T Create<T>()
        {
            return Container.Instantiate<T>();
        }
    }
}