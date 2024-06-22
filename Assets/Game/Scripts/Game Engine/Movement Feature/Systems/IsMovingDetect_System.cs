using Game.Scripts.Game_Engine.Movement_Feature.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Movement_Feature.Systems
{
    public struct IsMovingDetect_System : IEcsRunSystem
    {
        private EcsFilterInject<Inc<MoveDirection_Component, IsMoving_Component>> _filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var directionComponent = _filter.Pools.Inc1.Get(entity);
                ref var isMovingComponent = ref _filter.Pools.Inc2.Get(entity);

                isMovingComponent.Value = directionComponent.Direction != Vector3.zero;
            }
        }
    }
}