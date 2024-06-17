using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Movement_Feature
{
    public struct TransformMove_System : IEcsRunSystem
    {
        private EcsFilterInject<Inc<MoveTransform_Component, MoveDirection_Component, MoveSpeed_Component>> _filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var transformComponent = _filter.Pools.Inc1.Get(entity);
                var directionComponent = _filter.Pools.Inc2.Get(entity);
                var speedComponent = _filter.Pools.Inc3.Get(entity);

                transformComponent.Transform.position +=
                    directionComponent.Direction * speedComponent.Speed * Time.deltaTime;
            }
        }
    }
}