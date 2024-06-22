namespace Game.Scripts.Game_Engine.Item_Stack_Feature.Stack
{
    public readonly struct ItemStackFeatureParams
    {
        public readonly ItemStackContext Context;
        public readonly int Capacity;

        public ItemStackFeatureParams(ItemStackContext context, int capacity)
        {
            Context = context;
            Capacity = capacity;
        }
    }
}