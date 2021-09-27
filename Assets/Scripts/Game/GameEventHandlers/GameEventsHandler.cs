using System.Collections.Generic;
using LoonaTest.Game.GameActors.Penguins;

namespace LoonaTest.Game.GameEventHandlers
{
    public class GameEventsHandler
    {
        private PenguinOutOfBorderHandler _penguinOutOfBorderHandler;

        public void SetDependencies(PenguinsContainer penguinsContainer)
        {
            _penguinOutOfBorderHandler = new PenguinOutOfBorderHandler(penguinsContainer.Penguins);
        }

        public void OnPenguinOutOfBorder(Penguin penguin)
        {
            _penguinOutOfBorderHandler.OnPenguinOutOfBorder(penguin);
        }
    }
}