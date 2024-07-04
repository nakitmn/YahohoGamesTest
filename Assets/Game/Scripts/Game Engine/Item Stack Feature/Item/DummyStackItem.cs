using Game.Scripts.Game_Engine.Spawn_Feature;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game_Engine.Item_Stack_Feature.Item
{
    public class DummyStackItem : MonoBehaviour
    {
        private const string PREFIX = "DUMMY - ";

        [SerializeField] private StackItemConfig _config;

        private EcsWorld _ecsWorld;

        [Inject]
        public void Construct(EcsWorld ecsWorld)
        {
            _ecsWorld = ecsWorld;
        }

        private void OnValidate()
        {
            gameObject.name = _config == null
                ? $"{PREFIX}unknown"
                : $"{PREFIX}{_config.name}";
        }

        private void Start()
        {
            GenerateItem();
        }

        private void GenerateItem()
        {
            if (_config != null)
            {
                SpawnFeature.CreateEntity(
                    _ecsWorld,
                    new(
                        _config.Prefab.gameObject,
                        transform.position,
                        transform.rotation,
                        transform.parent
                    )
                );
            }

            Destroy(gameObject);
        }
    }
}