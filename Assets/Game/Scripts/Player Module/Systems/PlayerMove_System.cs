using Game.Scripts.Game_Engine.Movement_Feature;
using Game.Scripts.Game_Engine.Movement_Feature.Components;
using Game.Scripts.Input_Module;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game.Scripts.Player_Module.Systems
{
    public struct PlayerMove_System : IEcsRunSystem
    {
        private EcsWorldInject _world;
        private EcsPoolInject<MoveDirection_Component> _directionPool;

        private readonly PlayerContext _playerContext;
        private readonly IPlayerInput _playerInput;

        public PlayerMove_System(PlayerContext playerContext, IPlayerInput playerInput) : this()
        {
            _playerContext = playerContext;
            _playerInput = playerInput;
        }

        public void Run(IEcsSystems systems)
        {
            if (_playerContext.Entity.Unpack(_world.Value, out var entity) == false)
            {
                Debug.LogWarning($"Player Move system is broken! Can't unpack player entity!");
                return;
            }

            var rawDirection = _playerInput.MoveAxis;
            var direction = new Vector3(rawDirection.x, 0f, rawDirection.y);

            _directionPool.Value.Get(entity).Direction = direction;
        }
    }
}