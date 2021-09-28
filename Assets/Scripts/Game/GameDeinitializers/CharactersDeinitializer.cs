using LoonaTest.Game.GameActors.Characters;
using UnityEngine;

namespace LoonaTest.Game
{
    public class CharactersDeinitializer
    {
        private readonly CharactersContainer _container;

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