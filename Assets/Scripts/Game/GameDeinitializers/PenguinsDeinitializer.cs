using LoonaTest.Game.GameActors.Penguins;
using UnityEngine;
using VContainer;

namespace LoonaTest.Game.GameDeinitializers
{
    public class PenguinsDeinitializer
    {
        private readonly PenguinsContainer _container;

        [Inject]
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