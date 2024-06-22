using UnityEngine;

namespace Game.Scripts.Game_Engine.Movement_Feature
{
    public readonly struct MovementFeatureParams
    {
        public readonly Transform Transform;
        public readonly float Speed;

        public MovementFeatureParams(Transform transform, float speed)
        {
            Transform = transform;
            Speed = speed;
        }
    }
}