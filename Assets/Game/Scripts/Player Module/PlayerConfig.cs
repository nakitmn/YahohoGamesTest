using UnityEngine;

namespace Game.Scripts.Player_Module
{
    [CreateAssetMenu(menuName = "Game/Player/Config", order = 0)]
    public sealed class PlayerConfig : ScriptableObject
    {
        public float MoveSpeed = 10f;
        public float RotateSpeed = 10f;
    }
}