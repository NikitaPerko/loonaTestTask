using System.Collections.Generic;
using LoonaTest.Game.GameActors;
using LoonaTest.Game.GameActors.Characters;
using LoonaTest.Game.GameActors.Penguins;
using LoonaTest.Game.Settings;
using UnityEngine;

namespace LoonaTest.Game.GameInitializers
{
    public class CharactersInitializer
    {
        private readonly CharactersSettings _charactersSettings;

        public CharactersInitializer(CharactersSettings charactersSettings)
        {
            _charactersSettings = charactersSettings;
        }

        public void Init(GameField gameField, CharactersContainer charactersContainer, PenguinsContainer penguinsContainer)
        {
            charactersContainer.Characters = new List<Character>(_charactersSettings.PlayersCount);
            var randomPos = gameField.GetRandomFieldXZPos().GetXYZWithZeroY();
            var randomRotation = Quaternion.Euler(0, Random.value * 360f, 0);
            var playerCharacter = Object.Instantiate(_charactersSettings.Prefab, randomPos, randomRotation);
            playerCharacter.Init(CharacterOwner.Player, penguinsContainer, _charactersSettings);
            charactersContainer.Characters.Add(playerCharacter);

            for (int i = 0; i < _charactersSettings.PlayersCount - 1; i++)
            {
                var computerCharacter = Object.Instantiate(_charactersSettings.Prefab, randomPos, randomRotation);
                computerCharacter.Init(CharacterOwner.Computer, penguinsContainer, _charactersSettings);
                charactersContainer.Characters.Add(computerCharacter);
            }
        }
    }
}