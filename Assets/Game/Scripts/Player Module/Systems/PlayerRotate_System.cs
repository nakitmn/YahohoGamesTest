using Game.Scripts.Game_Engine.Movement_Feature.Components;
using Game.Scripts.Game_Engine.Rotation_Feature.Components;
using Game.Scripts.Input_Module;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game.Scripts.Player_Module.Systems
{
    public struct PlayerRotate_System : IEcsRunSystem
    {
        private EcsWorldInject _world;
        private EcsPoolInject<MoveDirection_Component> _moveDirectionPool;
        private EcsPoolInject<RotateDirection_Component> _rotateDirectionPool;

        private readonly PlayerContext _playerContext;

        public PlayerRotate_System(PlayerContext playerContext) : this()
        {
            _playerContext = playerContext;
        }

        public void Run(IEcsSystems systems)
        {
            if (_playerContext.Entity.Unpack(_world.Value, out var entity) == false)
            {
                Debug.LogWarning($"Player Rotate system is broken! Can't unpack player entity!");
                return;
            }

            _rotateDirectionPool.Value.Get(entity).Direction = _moveDirectionPool.Value.Get(entity).Direction;
        }
    }
}