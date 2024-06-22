using Game.Scripts.Game_Engine.Movement_Feature;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game_Engine.Item_Stack_Feature.Item
{
    public sealed class StackItemFactory
    {
        private DiContainer _diContainer;

        public StackItemFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public StackItemContext CreateItem(StackItemConfig config)
        {
            /*var stackItemContext = Object.Instantiate(config.Prefab);
            _diContainer.Inject(stackItemContext);
            return stackItemContext;*/

            return _diContainer.InstantiatePrefabForComponent<StackItemContext>(config.Prefab);
        }
    }
}