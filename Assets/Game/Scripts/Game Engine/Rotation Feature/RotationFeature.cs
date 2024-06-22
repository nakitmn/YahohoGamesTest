using Game.Scripts.Game_Engine.Rotation_Feature.Components;
using Leopotam.EcsLite;

namespace Game.Scripts.Game_Engine.Rotation_Feature
{
    public static class RotationFeature
    {
        public static void InitEntity(int entity, EcsWorld world, RotationFeatureParams featureParams)
        {
            var speedPool = world.GetPool<RotateSpeed_Component>();
            var transformPool = world.GetPool<RotateTransform_Component>();
            var directionPool = world.GetPool<RotateDirection_Component>();

            transformPool.Add(entity).Transform = featureParams.Transform;
            speedPool.Add(entity).Speed = featureParams.Speed;
            directionPool.Add(entity);
        }
    }
}