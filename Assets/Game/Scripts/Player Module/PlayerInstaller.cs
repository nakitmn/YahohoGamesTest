using Game.Scripts.Player_Module.Systems;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player_Module
{
    public sealed class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _config;

        public override void InstallBindings()
        {
            Container.Bind<PlayerConfig>()
                .FromInstance(_config)
                .AsSingle();
            
            Container.Bind<PlayerContext>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.BindInterfacesTo<PlayerInit_System>()
                .AsSingle();
        }
    }
}