using Game.Scripts.Game_Engine.Item_Stack_Feature.Stack;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI.Stack
{
    public sealed class StackCapacityAdapter : MonoBehaviour
    {
        [SerializeField] private ItemStackContext _stackContext;
        [SerializeField] private StackCapacityView _view;

        private EcsWorld _world;

        [Inject]
        public void Construct(EcsWorld world)
        {
            _world = world;
        }

        public void Update()
        {
            if (_stackContext.Entity.Unpack(_world, out var entity))
            {
                var freeSpaceComponent = _world.GetPool<FreeSpace_Component>().Get(entity);
                var capacityComponent = _world.GetPool<Capacity_Component>().Get(entity);
                var itemsAmount = capacityComponent.Value - freeSpaceComponent.Value;

                _view.SetStackCapacity($"({itemsAmount}/{capacityComponent.Value})");
            }
            else
            {
                _view.SetStackCapacity(string.Empty);
            }
        }
    }
}