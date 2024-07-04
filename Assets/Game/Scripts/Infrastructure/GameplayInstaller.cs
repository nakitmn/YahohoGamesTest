using UnityEngine;
using Zenject;

namespace Game.Scripts.Infrastructure
{
    public sealed class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Application.targetFrameRate = 60;
        }
    }
}