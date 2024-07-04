using TMPro;
using UnityEngine;

namespace Game.Scripts.UI.Timer
{
    public sealed class TimerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void SetTimerValue(string timerValue)
        {
            _text.text = timerValue;
        }
    }
}