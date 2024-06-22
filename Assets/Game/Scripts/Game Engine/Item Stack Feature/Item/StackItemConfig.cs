using UnityEngine;

namespace Game.Scripts.Game_Engine.Item_Stack_Feature.Item
{
    [CreateAssetMenu(menuName = "Game/Stack Item/Config", order = 0)]
    public sealed class StackItemConfig : ScriptableObject
    {
        [SerializeField] private StackItemContext _prefab;

        public StackItemContext Prefab => _prefab;
    }
}