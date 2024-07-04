using Zenject;

namespace Game.Scripts.Spawner_Module
{
    public class SpawnerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SpawnerContext>()
                .FromComponentsInHierarchy()
                .AsCached();
            
            Container.BindInterfacesTo<SpawnersInit_System>()
                .AsSingle();
        }
    }
}