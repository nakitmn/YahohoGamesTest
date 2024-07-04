using Game.Scripts.Game_Engine.Item_Stack_Feature.Item;
using Game.Scripts.Game_Engine.Spawn_Feature.Spawners.Radius_Spawner.Components;
using Game.Scripts.Spawner_Module;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Spawn_Feature
{
    public static class SpawnerFeature
    {
        public readonly struct FeatureParams
        {
            public readonly SpawnerContext Context;
            public readonly GameObject Prefab;
            public readonly Transform SpawnPoint;
            public readonly float SpawnRadius;

            public FeatureParams(SpawnerContext context, GameObject prefab, Transform spawnPoint, float spawnRadius)
            {
                Context = context;
                Prefab = prefab;
                SpawnPoint = spawnPoint;
                SpawnRadius = spawnRadius;
            }
        }

        public static int CreateEntity(EcsWorld world, FeatureParams featureParams)
        {
            var entity = world.NewEntity();
            InitEntity(entity, world, featureParams);
            return entity;
        }

        public static void InitEntity(int entity, EcsWorld world, FeatureParams featureParams)
        {
            FeatureHelper.RegisterComponent<SpawnPrefab_Component>(entity, world,
                pool => pool.Get(entity).Value = featureParams.Prefab);
            
            FeatureHelper.RegisterComponent<SpawnPoint_Component>(entity, world,
                pool => pool.Get(entity).Value = featureParams.SpawnPoint);
            
            FeatureHelper.RegisterComponent<SpawnRadius_Component>(entity, world,
                pool => pool.Get(entity).Value = featureParams.SpawnRadius);

            FeatureHelper.RegisterComponent<SpawnerContext_Component>(entity, world,
                pool => pool.Get(entity).Value = featureParams.Context);
            
            FeatureHelper.RegisterComponent<SpawnCount_Component>(entity, world);
        }
    }
}