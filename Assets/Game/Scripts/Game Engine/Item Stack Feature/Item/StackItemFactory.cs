using Zenject;

namespace Game.Scripts.Game_Engine.Item_Stack_Feature.Item
{
    public sealed class StackItemFactory
    {
        private readonly DiContainer _diContainer;

        public StackItemFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public StackItemContext CreateItem(StackItemConfig config)
        {
            return _diContainer.InstantiatePrefabForComponent<StackItemContext>(config.Prefab);
        }
    }
}