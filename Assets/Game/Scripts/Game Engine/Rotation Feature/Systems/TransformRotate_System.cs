using Game.Scripts.Game_Engine.Rotation_Feature.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Rotation_Feature.Systems
{
    public struct TransformRotate_System : IEcsRunSystem
    {
        private EcsFilterInject<Inc<RotateTransform_Component, RotateDirection_Component, RotateSpeed_Component>>
            _filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var transformComponent = _filter.Pools.Inc1.Get(entity);
                var directionComponent = _filter.Pools.Inc2.Get(entity);
                var speedComponent = _filter.Pools.Inc3.Get(entity);

                if (directionComponent.Direction == Vector3.zero)
                {
                    continue;
                }

                var lookRotation = Quaternion.LookRotation(directionComponent.Direction);

                transformComponent.Transform.rotation = Quaternion.Slerp(
                    transformComponent.Transform.rotation,
                    lookRotation,
                    speedComponent.Speed * Time.deltaTime
                );
            }
        }
    }
}