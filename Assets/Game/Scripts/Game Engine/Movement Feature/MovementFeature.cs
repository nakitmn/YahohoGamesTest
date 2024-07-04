using System;
using Game.Scripts.Game_Engine.Movement_Feature.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Movement_Feature
{
    public static class MovementFeature
    {
        public readonly struct FeatureParams
        {
            public readonly Transform Transform;
            public readonly float Speed;

            public FeatureParams(Transform transform, float speed)
            {
                Transform = transform;
                Speed = speed;
            }
        }
        
        public static void InitEntity(int entity, EcsWorld world, FeatureParams featureParams)
        {
            FeatureHelper.RegisterComponent<MoveTransform_Component>(entity, world,
                pool => pool.Get(entity).Transform = featureParams.Transform);

            FeatureHelper.RegisterComponent<MoveSpeed_Component>(entity, world,
                pool => pool.Get(entity).Speed = featureParams.Speed);

            FeatureHelper.RegisterComponent<MoveDirection_Component>(entity, world);
            FeatureHelper.RegisterComponent<IsMoving_Component>(entity, world);
            FeatureHelper.RegisterComponent<CurrentSpeed_Component>(entity, world);
        }
    }
}