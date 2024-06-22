using System;
using Game.Scripts.Game_Engine.Movement_Feature.Components;
using Leopotam.EcsLite;

namespace Game.Scripts.Game_Engine.Movement_Feature
{
    public static class MovementFeature
    {
        public static void InitEntity(int entity, EcsWorld world, MovementFeatureParams featureParams)
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