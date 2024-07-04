using Game.Scripts.Game_Engine.Spawn_Feature.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Spawn_Feature
{
    public static class SpawnFeature
    {
        public readonly struct FeatureParams
        {
            public readonly GameObject Prefab;
            public readonly Vector3 Position;
            public readonly Quaternion Rotation;
            public readonly Transform Parent;
            public readonly EcsPackedEntity CallbackEntity;

            public FeatureParams(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent, EcsPackedEntity callbackEntity = default)
            {
                Prefab = prefab;
                Position = position;
                Rotation = rotation;
                Parent = parent;
                CallbackEntity = callbackEntity;
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
                    spawnComponent.CallbackEntity = featureParams.CallbackEntity;
                }
            );
        }
    }
}