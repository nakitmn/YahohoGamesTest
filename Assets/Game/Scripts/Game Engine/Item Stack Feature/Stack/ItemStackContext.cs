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
            var itemTransform = stackItemContext.Transform;
            itemTransform.SetParent(_pivot);
            itemTransform.localPosition = Vector3.up * _offsetValue * index;
        }
    }
}