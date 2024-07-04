using Zenject;

namespace Game.Scripts.Game_Engine.Item_Stack_Feature.Item
{
    public sealed class StackItemModuleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<DummyStackItem>()
                .FromComponentsInHierarchy()
                .AsCached();
        }
    }
}