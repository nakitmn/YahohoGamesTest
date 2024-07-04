using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game_Engine.Item_Stack_Feature.Stack
{
    public sealed class DummyStack : MonoBehaviour
    {
        [SerializeField] private ItemStackContext _stackContext;
        [SerializeField] private int _capacity = 20;

        private EcsWorld _ecsWorld;

        [Inject]
        public void Construct(EcsWorld ecsWorld)
        {
            _ecsWorld = ecsWorld;
        }

        private void Start()
        {
            var stackEntity = _ecsWorld.NewEntity();
            _stackContext.Compose(_ecsWorld.PackEntity(stackEntity));

            ItemStackFeature.InitEntity(
                stackEntity,
                _ecsWorld,
                new (_stackContext, _capacity)
            );
            
            Destroy(this);
        }
    }
}