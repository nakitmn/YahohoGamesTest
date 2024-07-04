using System.Collections.Generic;
using Game.Scripts.Game_Engine.Item_Stack_Feature.Item;
using Game.Scripts.Game_Engine.Item_Stack_Feature.Stack;
using Game.Scripts.Game_Engine.Movement_Feature;
using Game.Scripts.Game_Engine.Rotation_Feature;
using Game.Scripts.Game_Engine.Timer_Feature;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Game.Scripts.Player_Module.Systems
{
    public struct PlayerInit_System : IEcsInitSystem
    {
        private EcsWorldInject _world;

        private readonly PlayerConfig _config;
        private readonly PlayerContext _context;

        public PlayerInit_System(PlayerConfig config, PlayerContext context) : this()
        {
            _config = config;
            _context = context;
        }

        public void Init(IEcsSystems systems)
        {
            var playerEntity = _world.Value.NewEntity();
            _context.Compose(_world.Value.PackEntity(playerEntity));

            MovementFeature.InitEntity(
                playerEntity,
                _world.Value,
                new MovementFeatureParams(_context.MoveTransform, _config.MoveSpeed)
            );

            RotationFeature.InitEntity(
                playerEntity,
                _world.Value,
                new RotationFeatureParams(_context.RotateTransform, _config.RotateSpeed)
            );

            var stackEntity = _world.Value.NewEntity();

            ItemStackFeature.InitEntity(
                stackEntity,
                _world.Value,
                new ItemStackFeatureParams(_context.ItemStackContext, _config.DefaultStackCapacity)
            );

            _world.Value.GetPool<TriggeredItems_Component>().Add(playerEntity).Value = new List<StackItemContext>();
            _world.Value.GetPool<StackEntity_Component>().Add(playerEntity).Value =
                _world.Value.PackEntity(stackEntity);
        }
    }
}