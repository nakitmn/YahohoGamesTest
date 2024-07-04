using UnityEngine;

namespace Game.Scripts.Game_Engine.Spawn_Feature
{
    public readonly struct SpawnFeatureParams
    {
        public readonly GameObject Prefab;
        public readonly Vector3 Position;
        public readonly Quaternion Rotation;
        public readonly Transform Parent;

        public SpawnFeatureParams(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
        {
            Prefab = prefab;
            Position = position;
            Rotation = rotation;
            Parent = parent;
        }
    }
}