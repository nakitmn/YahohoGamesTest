using Zenject;

namespace Game.Scripts.Input_Module
{
    public sealed class PlayerInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Joystick>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.Bind<IPlayerInput>()
                .To<JoystickPlayerInput>()
                .AsSingle();
        }
    }
}