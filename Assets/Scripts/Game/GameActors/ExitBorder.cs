using LoonaTest.Game.GameEventHandlers;
using UnityEngine;

namespace LoonaTest.Game
{
    public class ExitBorder : MonoBehaviour
    {
        private GameEventsHandler _gameEventsHandler;

        public void Init(GameEventsHandler gameEventsHandler)
        {
            _gameEventsHandler = gameEventsHandler;
        }

        private void OnTriggerEnter(Collider other)
        {
            var penguin = other.GetComponent<Penguin>();

            if (penguin != null)
            {
                _gameEventsHandler.OnPenguinOutOfBorder(penguin);
            }
        }
    }
}