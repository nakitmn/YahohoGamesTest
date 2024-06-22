using Game.Scripts.Game_Engine.Item_Stack_Feature.Item;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Item_Stack_Feature.Stack
{
    public struct PushTriggeredItemsToStack_System : IEcsRunSystem
    {
        private EcsWorldInject _world;
        private EcsFilterInject<Inc<TriggeredItems_Component, StackEntity_Component>> _filter;
        private EcsPoolInject<ItemsToAdd_Component> _itemsToAddPool;
        private EcsPoolInject<FreeSpace_Component> _freeSpacePool;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var itemsComponent = _filter.Pools.Inc1.Get(entity);
                var stackEntityComponent = _filter.Pools.Inc2.Get(entity);
                
                if (itemsComponent.Value.Count == 0)
                {
                    continue;
                }
                
                if (stackEntityComponent.Value.Unpack(_world.Value,out var stackEntity))
                {
                    var freeSpaceComponent = _freeSpacePool.Value.Get(stackEntity);
                    var itemsToAddComponent = _itemsToAddPool.Value.Get(stackEntity);

                    var pushAmount = Mathf.Min(itemsComponent.Value.Count, freeSpaceComponent.Value);
                    
                    for (var i = 0; i < pushAmount; i++)
                    {
                        var stackItemContext = itemsComponent.Value[i];
                        itemsToAddComponent.Value.Add(stackItemContext);
                    }
                }
            }
        }
    }
}