using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.Player_Module
{
    public sealed class PlayerContext : MonoBehaviour
    {
        [SerializeField] private Transform _moveTransform;
        [SerializeField] private Transform _rotateTransform;
        [SerializeField] private Animator _animator;
        
        public EcsPackedEntity Entity { get; set; }
        public Transform MoveTransform => _moveTransform;
        public Transform RotateTransform => _rotateTransform;
        public Animator Animator => _animator;
    }
}