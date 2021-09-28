using LoonaTest.Game.GameActors.Penguins;
using UnityEngine;

namespace LoonaTest.Game
{
    public class PenguinsDeinitializer
    {
        private readonly PenguinsContainer _container;

        public PenguinsDeinitializer(PenguinsContainer container)
        {
            _container = container;
        }

        public void Deinit()
        {
            foreach (var penguin in _container.Penguins)
            {
                penguin.Deinit();
                Object.Destroy(penguin.gameObject);
            }

            _container.Penguins.Clear();
        }
    }
}