using System.Collections.Generic;
using LoonaTest.Game.GameActors.Penguins;
using UnityEngine;
using VContainer;

namespace LoonaTest.Game.GameEventHandlers
{
    public class PenguinOutOfBorderHandler : IPenguinOutOfBorderHandler
    {
        private readonly PenguinsContainer _penguinsContainer;
        private readonly IPenguinsAreOverHandler _penguinsAreOverHandler;

        [Inject]
        public PenguinOutOfBorderHandler(PenguinsContainer penguinsContainer, IPenguinsAreOverHandler penguinsAreOverHandler)
        {
            _penguinsContainer = penguinsContainer;
            _penguinsAreOverHandler = penguinsAreOverHandler;
        }

        public void OnPenguinOutOfBorder(Penguin penguin)
        {
            _penguinsContainer.Penguins.Remove(penguin);
            penguin.Deinit();
            Object.Destroy(penguin.gameObject);

            if (_penguinsContainer.Penguins.Count == 0)
            {
                _penguinsAreOverHandler.OnPenguinsAreOver();
            }
        }
    }
}