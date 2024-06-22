using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Game.Scripts.Game_Engine.Item_Stack_Feature.Stack
{
    public struct FreeSpaceCounter_System : IEcsRunSystem
    {
        private EcsFilterInject<Inc<ItemStack_Component, Capacity_Component, FreeSpace_Component>> _filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var stackComponent = _filter.Pools.Inc1.Get(entity);
                var capacityComponent = _filter.Pools.Inc2.Get(entity);
                ref var freeSpaceComponent = ref _filter.Pools.Inc3.Get(entity);

                freeSpaceComponent.Value = capacityComponent.Value - stackComponent.Value.Count;
            }
        }
    }
}