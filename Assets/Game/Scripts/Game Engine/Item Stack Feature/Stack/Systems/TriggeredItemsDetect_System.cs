using Game.Scripts.Game_Engine.Item_Stack_Feature.Item;
using Game.Scripts.Game_Engine.Trigger_Feature;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Game.Scripts.Game_Engine.Item_Stack_Feature.Stack
{
    public struct TriggeredItemsDetect_System : IEcsRunSystem
    {
        private EcsFilterInject<Inc<Triggers_Component, TriggeredItems_Component>> _filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var triggersComponent = _filter.Pools.Inc1.Get(entity);
                ref var itemsComponent = ref _filter.Pools.Inc2.Get(entity);

                itemsComponent.Value.Clear();

                foreach (var collider in triggersComponent.Colliders)
                {
                    if (collider.TryGetComponent<StackItemContext>(out var stackItemContext))
                    {
                        itemsComponent.Value.Add(stackItemContext);
                    }
                }
            }
        }
    }
}