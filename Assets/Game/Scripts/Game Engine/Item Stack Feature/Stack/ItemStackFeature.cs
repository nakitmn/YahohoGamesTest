using System.Collections.Generic;
using Game.Scripts.Game_Engine.Item_Stack_Feature.Item;
using Leopotam.EcsLite;

namespace Game.Scripts.Game_Engine.Item_Stack_Feature.Stack
{
    public static class ItemStackFeature
    {
        public readonly struct FeatureParams
        {
            public readonly ItemStackContext Context;
            public readonly int Capacity;

            public FeatureParams(ItemStackContext context, int capacity)
            {
                Context = context;
                Capacity = capacity;
            }
        }
        
        public static void InitEntity(int entity, EcsWorld world, FeatureParams featureParams)
        {
            FeatureHelper.RegisterComponent<ItemStackContext_Component>(entity, world, 
                pool => pool.Get(entity).Value = featureParams.Context);
            
            FeatureHelper.RegisterComponent<Capacity_Component>(entity, world, 
                pool => pool.Get(entity).Value = featureParams.Capacity);
            
            FeatureHelper.RegisterComponent<ItemStack_Component>(entity, world, 
                pool => pool.Get(entity).Value = new Stack<StackItemContext>());

            FeatureHelper.RegisterComponent<ItemsToAdd_Component>(entity, world, 
                pool => pool.Get(entity).Value = new List<StackItemContext>());
            
            FeatureHelper.RegisterComponent<FreeSpace_Component>(entity, world);
        }
    }
}