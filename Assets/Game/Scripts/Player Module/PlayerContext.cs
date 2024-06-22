using Game.Scripts.Game_Engine.Item_Stack_Feature.Item;
using Game.Scripts.Game_Engine.Item_Stack_Feature.Stack;
using Game.Scripts.Game_Engine.Trigger_Feature;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.Player_Module
{
    public sealed class PlayerContext : MonoBehaviour
    {
        [SerializeField] private Transform _moveTransform;
        [SerializeField] private Transform _rotateTransform;
        [SerializeField] private Animator _animator;
        [SerializeField] private MonoTriggersContext _stackTriggersContext;
        [SerializeField] private ItemStackContext _itemStackContext;
        
        
        public EcsPackedEntity Entity { get; private set; }

        public ItemStackContext ItemStackContext => _itemStackContext;

        public Transform MoveTransform => _moveTransform;
        public Transform RotateTransform => _rotateTransform;
        public Animator Animator => _animator;

        public void Compose(EcsPackedEntity packedEntity)
        {
            Entity = packedEntity;
            _stackTriggersContext.Compose(packedEntity);
        }
    }
}