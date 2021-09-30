using LoonaTest.Game.GameActors.Penguins;
using LoonaTest.Game.GameEventHandlers;
using UnityEngine;

namespace LoonaTest.Game.GameActors
{
    public class ExitBorder : MonoBehaviour
    {
        private IPenguinOutOfBorderHandler _penguinOutOfBorderHandler;

        public void Init(IPenguinOutOfBorderHandler penguinOutOfBorderHandler)
        {
            _penguinOutOfBorderHandler = penguinOutOfBorderHandler;
        }

        private void OnTriggerEnter(Collider other)
        {
            var penguin = other.GetComponent<Penguin>();

            if (penguin != null)
            {
                _penguinOutOfBorderHandler.OnPenguinOutOfBorder(penguin);
            }
        }
    }
}