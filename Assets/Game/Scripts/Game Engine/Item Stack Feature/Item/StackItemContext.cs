using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Item_Stack_Feature.Item
{
    public class StackItemContext : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Collider _collider;
        
        public Transform Transform => _transform;

        public void OnAddedToStack()
        {
            _collider.enabled = false;
        }
    }
}