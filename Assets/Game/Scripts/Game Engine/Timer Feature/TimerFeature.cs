using Game.Scripts.Game_Engine.Timer_Feature.Components;
using Leopotam.EcsLite;

namespace Game.Scripts.Game_Engine.Timer_Feature
{
    public static class TimerFeature
    {
        public static void InitEntity(int entity, EcsWorld world, TimerFeatureParams featureParams)
        {
            FeatureHelper.RegisterComponent<Timer_Component>(
                entity, 
                world,
                pool =>
                {
                    ref var timerComponent = ref pool.Get(entity);
                    timerComponent.Duration = timerComponent.Remain = featureParams.Duration;
                });

            FeatureHelper.RegisterComponent<IsRepeatable_Component>(entity, world,
                pool => pool.Get(entity).Value = featureParams.IsRepeatable);
            
            FeatureHelper.RegisterComponent<IsTimerExpired_Component>(entity, world);
        }
    }
}