using System.Collections.Generic;
using LoonaTest.Game.GameActors;
using LoonaTest.Game.GameActors.Characters;
using LoonaTest.Game.GameActors.Penguins;
using LoonaTest.Game.Settings;
using UnityEngine;
using VContainer;

namespace LoonaTest.Game.GameInitializers
{
    public class CharactersInitializer
    {
        private readonly CharactersSettings _charactersSettings;
        private readonly GameFieldContainer _gameFieldContainer;
        private readonly CharactersContainer _charactersContainer;
        private readonly PenguinsContainer _penguinsContainer;

        [Inject]
        public CharactersInitializer(CharactersSettings charactersSettings, GameFieldContainer gameFieldContainer,
            CharactersContainer charactersContainer,
            PenguinsContainer penguinsContainer)
        {
            _charactersSettings = charactersSettings;
            _gameFieldContainer = gameFieldContainer;
            _charactersContainer = charactersContainer;
            _penguinsContainer = penguinsContainer;
        }

        public void Init()
        {
            _charactersContainer.Characters = new List<Character>(_charactersSettings.PlayersCount);
            var randomPos = _gameFieldContainer.GameField.GetRandomFieldXZPos().GetXYZWithZeroY();
            var randomRotation = Quaternion.Euler(0, Random.value * 360f, 0);
            var playerCharacter = Object.Instantiate(_charactersSettings.Prefab, randomPos, randomRotation);
            playerCharacter.Init(CharacterOwner.Player, _penguinsContainer, _charactersSettings);
            _charactersContainer.Characters.Add(playerCharacter);

            for (int i = 0; i < _charactersSettings.PlayersCount - 1; i++)
            {
                var computerCharacter = Object.Instantiate(_charactersSettings.Prefab, randomPos, randomRotation);
                computerCharacter.Init(CharacterOwner.Computer, _penguinsContainer, _charactersSettings);
                _charactersContainer.Characters.Add(computerCharacter);
            }
        }
    }
}