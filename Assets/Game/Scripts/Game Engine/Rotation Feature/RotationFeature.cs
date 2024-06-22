using Game.Scripts.Game_Engine.Rotation_Feature.Components;
using Leopotam.EcsLite;

namespace Game.Scripts.Game_Engine.Rotation_Feature
{
    public static class RotationFeature
    {
        public static void InitEntity(int entity, EcsWorld world, RotationFeatureParams featureParams)
        {
            FeatureHelper.RegisterComponent<RotateTransform_Component>(entity, world,
                pool => pool.Get(entity).Transform = featureParams.Transform);
            
            FeatureHelper.RegisterComponent<RotateSpeed_Component>(entity, world,
                pool => pool.Get(entity).Speed = featureParams.Speed);
            
            FeatureHelper.RegisterComponent<RotateDirection_Component>(entity, world);
        }
    }
}