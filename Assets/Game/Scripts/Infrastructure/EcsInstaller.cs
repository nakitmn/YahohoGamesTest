using System;
using Game.Scripts.Game_Engine.Item_Stack_Feature.Stack;
using Game.Scripts.Game_Engine.Movement_Feature.Systems;
using Game.Scripts.Game_Engine.Rotation_Feature.Systems;
using Game.Scripts.Game_Engine.Spawn_Feature.Spawners.Radius_Spawner.Systems;
using Game.Scripts.Game_Engine.Spawn_Feature.Systems;
using Game.Scripts.Game_Engine.Timer_Feature.Systems;
using Game.Scripts.Player_Module.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Mitfart.LeoECSLite.UnityIntegration;
using Zenject;

namespace Game.Scripts.Infrastructure
{
    public sealed class EcsInstaller : MonoInstaller
    {
        private IEcsSystems _systems;

        public override void InstallBindings()
        {
            var world = new EcsWorld();
            _systems = new EcsSystems(world);

            Container.Bind<EcsWorld>()
                .FromInstance(world)
                .AsSingle();
            
            Container.Bind<IEcsSystems>()
                .FromInstance(_systems)
                .AsSingle();
        }

        public void Awake()
        {
            AddInitSystems();

            _systems
                .Add(Create<TransformMove_System>())
                .Add(Create<CurrentSpeedDetect_System>())
                .Add(Create<IsMovingDetect_System>())
                .Add(Create<TransformRotate_System>())
                .Add(Create<FreeSpaceCounter_System>())
                .Add(Create<TriggeredItemsDetect_System>())
                .Add(Create<TriggeredStacksDetect_System>())
                .Add(Create<PushTriggeredItemsToStack_System>())
                .Add(Create<PushItemsToTriggeredStack_System>())
                .Add(Create<AddItemsToStack_System>())
                .Add(Create<PlayerMove_System>())
                .Add(Create<PlayerRotate_System>())
                .Add(Create<PlayerAnimator_System>())
                .Add(Create<TimerTick_System>())
                .Add(Create<TimerExpiredTrack_System>())
                .Add(Create<RepeatTimer_System>())
                .Add(Create<SpawnOnTimerExpired_System>())
                .Add(Create<Spawner_System>())
                .Add(Create<SpawnerCompleteHandle_System>())
                .Add(Create<Spawn_System>())
#if UNITY_EDITOR
                .Add(new EcsWorldDebugSystem())
#endif
                .Inject();
        }

        private void AddInitSystems()
        {
            var initSystems = Container.Resolve<IEcsInitSystem[]>();

            foreach (var initSystem in initSystems)
            {
                _systems.Add(initSystem);
            }
        }

        private T Create<T>()
        {
            return Container.Instantiate<T>();
        }
    }
}