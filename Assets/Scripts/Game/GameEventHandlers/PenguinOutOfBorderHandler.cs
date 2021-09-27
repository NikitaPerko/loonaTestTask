using System.Collections.Generic;
using LoonaTest.Game.GameActors.Penguins;
using UnityEngine;

namespace LoonaTest.Game.GameEventHandlers
{
    public class PenguinOutOfBorderHandler
    {
        private readonly List<Penguin> _penguins;
        public PenguinOutOfBorderHandler(List<Penguin> penguins)
        {
            _penguins = penguins;
        }

        public void OnPenguinOutOfBorder(Penguin penguin)
        {
            _penguins.Remove(penguin);
            Object.Destroy(penguin.gameObject);
        }
    }
}