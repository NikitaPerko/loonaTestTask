using TMPro;
using UnityEngine;

namespace LoonaTest
{
    public class GameWindow : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI timerValue;

        public void SetTime(int value)
        {
            timerValue.SetText(value.ToString());
        }
    }
}