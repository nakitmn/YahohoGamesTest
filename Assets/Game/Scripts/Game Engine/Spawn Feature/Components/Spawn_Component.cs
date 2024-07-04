using UnityEngine;

namespace Game.Scripts.Game_Engine.Spawn_Feature.Components
{
    public struct Spawn_Component
    {
        public GameObject Prefab;
        public Vector3 Position;
        public Quaternion Rotation;
        public Transform Parent;
    }
}