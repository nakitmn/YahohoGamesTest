using Game.Scripts.Game_Engine.Movement_Feature;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Game.Scripts.Player_Module.Systems
{
    public struct PlayerInit_System : IEcsInitSystem
    {
        private EcsWorldInject _world;
        private EcsPoolInject<MoveSpeed_Component> _speedPool;
        private EcsPoolInject<MoveDirection_Component> _directionPool;
        private EcsPoolInject<MoveTransform_Component> _transformPool;

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

            _speedPool.Value.Add(playerEntity).Speed = _config.MoveSpeed;
            _transformPool.Value.Add(playerEntity).Transform = _context.MoveTransform;
            _directionPool.Value.Add(playerEntity);

            _context.Entity = _world.Value.PackEntity(playerEntity);
        }
    }
}