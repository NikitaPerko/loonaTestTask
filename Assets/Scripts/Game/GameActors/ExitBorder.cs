using LoonaTest.Game.GameActors.Penguins;
using LoonaTest.Game.GameEventHandlers;
using UnityEngine;

namespace LoonaTest.Game.GameActors
{
    public class ExitBorder : MonoBehaviour
    {
        private IGameEventsHandler _gameEventsHandler;

        public void Init(IGameEventsHandler gameEventsHandler)
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