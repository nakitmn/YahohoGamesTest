using UnityEngine;

namespace Game.Scripts.Game_Engine.Rotation_Feature
{
    public readonly struct RotationFeatureParams
    {
        public readonly Transform Transform;
        public readonly float Speed;

        public RotationFeatureParams(Transform transform, float speed)
        {
            Transform = transform;
            Speed = speed;
        }
    }
}