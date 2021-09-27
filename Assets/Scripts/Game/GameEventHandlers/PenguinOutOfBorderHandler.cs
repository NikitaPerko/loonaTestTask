using UnityEngine;

namespace LoonaTest.Game.GameEventHandlers
{
    public class PenguinOutOfBorderHandler
    {
        public PenguinOutOfBorderHandler() { }

        public void OnPenguinOutOfBorder(Penguin penguin)
        {
            Object.Destroy(penguin.gameObject);
        }
    }
}