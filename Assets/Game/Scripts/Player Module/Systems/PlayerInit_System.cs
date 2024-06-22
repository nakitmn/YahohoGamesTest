using Game.Scripts.Game_Engine.Movement_Feature;
using Game.Scripts.Game_Engine.Movement_Feature.Components;
using Game.Scripts.Game_Engine.Rotation_Feature;
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
            _context.Entity = _world.Value.PackEntity(playerEntity);

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
        }
    }
}