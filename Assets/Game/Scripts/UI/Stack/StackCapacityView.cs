using TMPro;
using UnityEngine;

namespace Game.Scripts.UI.Stack
{
    public sealed class StackCapacityView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void SetStackCapacity(string timerValue)
        {
            _text.text = timerValue;
        }
    }
}