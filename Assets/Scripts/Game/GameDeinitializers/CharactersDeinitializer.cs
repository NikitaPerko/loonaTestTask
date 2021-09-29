using LoonaTest.Game.GameActors.Characters;
using UnityEngine;
using VContainer;

namespace LoonaTest.Game.GameDeinitializers
{
    public class CharactersDeinitializer
    {
        private readonly CharactersContainer _container;

        [Inject]
        public CharactersDeinitializer(CharactersContainer container)
        {
            _container = container;
        }

        public void Deinit()
        {
            foreach (var character in _container.Characters)
            {
                Object.Destroy(character.gameObject);
            }

            _container.Characters.Clear();
        }
    }
}