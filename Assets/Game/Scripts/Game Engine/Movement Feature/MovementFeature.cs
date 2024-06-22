using Game.Scripts.Game_Engine.Movement_Feature.Components;
using Leopotam.EcsLite;

namespace Game.Scripts.Game_Engine.Movement_Feature
{
    public static class MovementFeature
    {
        public static void InitEntity(int entity, EcsWorld world, MovementFeatureParams featureParams)
        {
            var speedPool = world.GetPool<MoveSpeed_Component>();
            var transformPool = world.GetPool<MoveTransform_Component>();
            var directionPool = world.GetPool<MoveDirection_Component>();

            transformPool.Add(entity).Transform = featureParams.Transform;
            speedPool.Add(entity).Speed = featureParams.Speed;
            directionPool.Add(entity);
        }
    }
}