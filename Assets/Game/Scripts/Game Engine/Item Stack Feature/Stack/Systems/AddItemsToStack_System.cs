using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Item_Stack_Feature.Stack
{
    public struct AddItemsToStack_System : IEcsRunSystem
    {
        private EcsWorldInject _world;

        private EcsFilterInject<Inc<ItemStack_Component, ItemsToAdd_Component, FreeSpace_Component,
            ItemStackContext_Component>> _filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var stackComponent = _filter.Pools.Inc1.Get(entity);
                var itemsToAddComponent = _filter.Pools.Inc2.Get(entity);
                var freeSpaceComponent = _filter.Pools.Inc3.Get(entity);
                var contextComponent = _filter.Pools.Inc4.Get(entity);

                var pushAmount = Mathf.Min(itemsToAddComponent.Value.Count, freeSpaceComponent.Value);

                for (var i = 0; i < pushAmount; i++)
                {
                    var stackItemContext = itemsToAddComponent.Value[i];
                    if (stackComponent.Value.Contains(stackItemContext))
                    {
                        continue;
                    }
                    contextComponent.Value.Push(stackItemContext, stackComponent.Value.Count);
                    stackComponent.Value.Push(stackItemContext);
                    stackItemContext.OnAddedToStack();
                }

                itemsToAddComponent.Value.Clear();
            }
        }
    }
}