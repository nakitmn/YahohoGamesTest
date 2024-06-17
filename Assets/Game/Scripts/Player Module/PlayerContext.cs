using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.Player_Module
{
    public sealed class PlayerContext : MonoBehaviour
    {
        public Transform MoveTransform => _moveTransform;

        [SerializeField] private Transform _moveTransform;

        public EcsPackedEntity Entity { get; set; }
    }
}