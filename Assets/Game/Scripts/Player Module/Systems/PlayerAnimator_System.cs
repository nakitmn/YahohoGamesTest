using Game.Scripts.Game_Engine.Movement_Feature.Components;
using Game.Scripts.Input_Module;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game.Scripts.Player_Module.Systems
{
    public struct PlayerAnimator_System : IEcsRunSystem
    {
        private static readonly int State = Animator.StringToHash("State");
        private static readonly int MoveSpeedNormalized = Animator.StringToHash("MoveSpeedNormalized");

        private EcsWorldInject _world;
        private EcsPoolInject<IsMoving_Component> _isMovingPool;
        private EcsPoolInject<CurrentSpeed_Component> _currentSpeedPool;

        private readonly PlayerContext _playerContext;

        public PlayerAnimator_System(PlayerContext playerContext) : this()
        {
            _playerContext = playerContext;
        }

        public void Run(IEcsSystems systems)
        {
            if (_playerContext.Entity.Unpack(_world.Value, out var entity) == false)
            {
                Debug.LogWarning($"{nameof(PlayerAnimator_System)} is broken! Can't unpack player entity!");
                return;
            }

            bool isMoving = _isMovingPool.Value.Get(entity).Value;
            _playerContext.Animator.SetInteger(State, isMoving ? 1 : 0);
            
            if (isMoving)
            {
                _playerContext.Animator.SetFloat(MoveSpeedNormalized, _currentSpeedPool.Value.Get(entity).NormalizedValue);
            }
        }
    }
}