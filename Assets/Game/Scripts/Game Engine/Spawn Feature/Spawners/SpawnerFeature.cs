using Game.Scripts.Game_Engine.Spawn_Feature.Spawners.Radius_Spawner.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Spawn_Feature
{
    public static class SpawnerFeature
    {
        public readonly struct FeatureParams
        {
            public readonly GameObject Prefab;
            public readonly Transform SpawnPoint;
            public readonly float SpawnRadius;

            public FeatureParams(GameObject prefab, Transform spawnPoint, float spawnRadius)
            {
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

            FeatureHelper.RegisterComponent<SpawnCount_Component>(entity, world);
        }
    }
}