using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Item_Stack_Feature.Stack
{
    public struct PushItemsToTriggeredStack_System : IEcsRunSystem
    {
        private EcsWorldInject _world;
        private EcsFilterInject<Inc<TriggeredStacks_Component, StackEntity_Component>> _filter;
        private EcsPoolInject<ItemsToAdd_Component> _itemsToAddPool;
        private EcsPoolInject<FreeSpace_Component> _freeSpacePool;
        private EcsPoolInject<ItemStack_Component> _itemStackPool;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var triggeredStacksComponent = _filter.Pools.Inc1.Get(entity);
                var stackEntityComponent = _filter.Pools.Inc2.Get(entity);

                if (triggeredStacksComponent.Value.Count == 0)
                {
                    continue;
                }

                var targetStack = triggeredStacksComponent.Value[0];

                if (targetStack.Entity.Unpack(_world.Value, out var targetStackEntity) == false)
                {
                    continue;
                }

                if (stackEntityComponent.Value.Unpack(_world.Value, out var stackEntity) == false)
                {
                    continue;
                }

                var freeSpaceComponent = _freeSpacePool.Value.Get(targetStackEntity);
                var itemsToAddComponent = _itemsToAddPool.Value.Get(targetStackEntity);
                var itemStackComponent = _itemStackPool.Value.Get(stackEntity);

                var pushAmount = Mathf.Min(itemStackComponent.Value.Count, freeSpaceComponent.Value);

                for (var i = 0; i < pushAmount; i++)
                {
                    var stackItemContext = itemStackComponent.Value.Pop();
                    itemsToAddComponent.Value.Add(stackItemContext);
                }
            }
        }
    }
}