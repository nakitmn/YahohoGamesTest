using Game.Scripts.Game_Engine.Movement_Feature.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Movement_Feature.Systems
{
    public struct CurrentSpeedDetect_System : IEcsRunSystem
    {
        private EcsFilterInject<Inc<MoveDirection_Component,MoveSpeed_Component, CurrentSpeed_Component>> _filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var directionComponent = _filter.Pools.Inc1.Get(entity);
                var speedComponent = _filter.Pools.Inc2.Get(entity);
                ref var currentSpeedComponent = ref _filter.Pools.Inc3.Get(entity);

                float currentSpeed = directionComponent.Direction.magnitude * speedComponent.Speed;
                float normalizedSpeed = currentSpeed / speedComponent.Speed;
                
                currentSpeedComponent.Value =  currentSpeed;
                currentSpeedComponent.NormalizedValue =  normalizedSpeed;
            }
        }
    }
}