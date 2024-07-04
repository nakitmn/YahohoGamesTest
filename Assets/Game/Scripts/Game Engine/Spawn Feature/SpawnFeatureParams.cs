using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Spawn_Feature
{
    public readonly struct SpawnFeatureParams
    {
        public readonly GameObject Prefab;
        public readonly Vector3 Position;
        public readonly Quaternion Rotation;
        public readonly Transform Parent;
        public readonly EcsPackedEntity CallbackEntity;

        public SpawnFeatureParams(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent, EcsPackedEntity callbackEntity = default)
        {
            Prefab = prefab;
            Position = position;
            Rotation = rotation;
            Parent = parent;
            CallbackEntity = callbackEntity;
        }
    }
}