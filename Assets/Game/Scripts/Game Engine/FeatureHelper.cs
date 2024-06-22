using System;
using Leopotam.EcsLite;

namespace Game.Scripts.Game_Engine
{
    public static class FeatureHelper
    {
        public static void RegisterComponent<TComponent>(int entity, EcsWorld world,
            Action<EcsPool<TComponent>> onComponentCreated = null) where TComponent : struct
        {
            var componentPool = world.GetPool<TComponent>();
            componentPool.Add(entity);
            onComponentCreated?.Invoke(componentPool);
        }
    }
}