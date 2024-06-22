using UnityEngine;
using Zenject;

namespace Game.Scripts.Game_Engine.Item_Stack_Feature.Item
{
    public class DummyStackItem : MonoBehaviour
    {
        private const string PREFIX = "DUMMY - ";
        
        [SerializeField] private StackItemConfig _config;
        
        private StackItemFactory _factory;

        [Inject]
        public void Construct(StackItemFactory factory)
        {
            _factory = factory;
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
                var stackItemContext = _factory.CreateItem(_config);
                stackItemContext.Transform.SetParent(transform.parent);
                stackItemContext.Transform.localPosition = transform.localPosition;
                stackItemContext.Transform.localRotation = transform.localRotation;
            }

            Destroy(gameObject);
        }
    }
}