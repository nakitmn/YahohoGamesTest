using Game.Scripts.Game_Engine.Rotation_Feature.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Rotation_Feature
{
    public static class RotationFeature
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
            FeatureHelper.RegisterComponent<RotateTransform_Component>(entity, world,
                pool => pool.Get(entity).Transform = featureParams.Transform);

            FeatureHelper.RegisterComponent<RotateSpeed_Component>(entity, world,
                pool => pool.Get(entity).Speed = featureParams.Speed);

            FeatureHelper.RegisterComponent<RotateDirection_Component>(entity, world);
        }
    }
}