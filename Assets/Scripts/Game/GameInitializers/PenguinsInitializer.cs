using System.Collections.Generic;
using LoonaTest.Game.GameActors;
using LoonaTest.Game.GameActors.Characters;
using LoonaTest.Game.GameActors.Penguins;
using LoonaTest.Game.Settings;
using UnityEngine;
using VContainer;

namespace LoonaTest.Game.GameInitializers
{
    public class PenguinsInitializer
    {
        private readonly PenguinsSettings _penguinsSettings;
        private readonly PenguinsContainer _penguinsContainer;
        private readonly CharactersContainer _charactersContainer;
        private readonly GameFieldContainer _gameFieldContainer;

        [Inject]
        public PenguinsInitializer(PenguinsSettings penguinsSettings, PenguinsContainer penguinsContainer,
            CharactersContainer charactersContainer, GameFieldContainer gameFieldContainer)
        {
            _penguinsSettings = penguinsSettings;
            _penguinsContainer = penguinsContainer;
            _charactersContainer = charactersContainer;
            _gameFieldContainer = gameFieldContainer;
        }

        public void Init()
        {
            _penguinsContainer.Penguins = new List<Penguin>(_penguinsSettings.penguinsCount);

            for (int i = 0; i < _penguinsSettings.penguinsCount; i++)
            {
                var randomPos = _gameFieldContainer.GameField.GetRandomFieldXZPos();
                var position = new Vector3(randomPos.x, 0, randomPos.y);
                var rotation = Quaternion.Euler(0, Random.value * 360, 0);
                var penguin = Object.Instantiate(_penguinsSettings.PenguinPrefab, position, rotation);
                penguin.Init(_charactersContainer, _penguinsSettings, _gameFieldContainer.GameField);
                _penguinsContainer.Penguins.Add(penguin);
            }
        }
    }
}