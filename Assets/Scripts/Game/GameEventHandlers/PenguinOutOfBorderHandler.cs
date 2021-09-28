using System.Collections.Generic;
using LoonaTest.Game.GameActors.Penguins;
using UnityEngine;

namespace LoonaTest.Game.GameEventHandlers
{
    public class PenguinOutOfBorderHandler
    {
        private readonly List<Penguin> _penguins;
        private readonly PenguinsAreOverHandler _penguinsAreOverHandler;

        public PenguinOutOfBorderHandler(List<Penguin> penguins, PenguinsAreOverHandler penguinsAreOverHandler)
        {
            _penguins = penguins;
            _penguinsAreOverHandler = penguinsAreOverHandler;
        }

        public void OnPenguinOutOfBorder(Penguin penguin)
        {
            _penguins.Remove(penguin);
            penguin.Deinit();
            Object.Destroy(penguin.gameObject);

            if (_penguins.Count == 0)
            {
                _penguinsAreOverHandler.OnPenguinsAreOver();
            }
        }
    }
}