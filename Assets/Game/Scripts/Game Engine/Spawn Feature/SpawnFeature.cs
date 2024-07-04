using Game.Scripts.Game_Engine.Spawn_Feature.Components;
using Leopotam.EcsLite;

namespace Game.Scripts.Game_Engine.Spawn_Feature
{
    public static class SpawnFeature
    {
        public static int CreateEntity(EcsWorld world, SpawnFeatureParams featureParams)
        {
            var entity = world.NewEntity();
            InitEntity(entity, world, featureParams);
            return entity;
        }

        public static void InitEntity(int entity, EcsWorld world, SpawnFeatureParams featureParams)
        {
            FeatureHelper.RegisterComponent<Spawn_Component>(
                entity,
                world,
                pool =>
                {
                    ref var spawnComponent = ref pool.Get(entity);
                    spawnComponent.Prefab = featureParams.Prefab;
                    spawnComponent.Position = featureParams.Position;
                    spawnComponent.Rotation = featureParams.Rotation;
                    spawnComponent.Parent = featureParams.Parent;
                }
            );
        }
    }
}