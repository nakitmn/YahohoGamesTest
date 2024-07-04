using DG.Tweening;
using Game.Scripts.Game_Engine.Item_Stack_Feature.Item;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Item_Stack_Feature.Stack
{
    public sealed class ItemStackContext : MonoBehaviour
    {
        [SerializeField] private Transform _pivot;
        [SerializeField] private float _offsetValue = 0.25f;
        
        public void Push(StackItemContext stackItemContext, int index)
        {
            var stackPosition = GetStackPositionFor(index);
            var itemTransform = stackItemContext.Transform;
            itemTransform.SetParent(_pivot);
            itemTransform.DOLocalJump(stackPosition, 1f, 1, 0.15f);
        }

        private Vector3 GetStackPositionFor(int index)
        {
            return Vector3.up * _offsetValue * index;
        }
    }
}