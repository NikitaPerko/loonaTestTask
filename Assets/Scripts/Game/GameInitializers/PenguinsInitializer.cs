using System.Collections.Generic;
using LoonaTest.Game.GameActors;
using LoonaTest.Game.GameActors.Characters;
using LoonaTest.Game.GameActors.Penguins;
using LoonaTest.Game.Settings;
using UnityEngine;

namespace LoonaTest.Game.GameInitializers
{
    public class PenguinsInitializer
    {
        private readonly PenguinsSettings _penguinsSettings;

        public PenguinsInitializer(PenguinsSettings penguinsSettings)
        {
            _penguinsSettings = penguinsSettings;
        }

        public void Init(GameField gameField, PenguinsContainer penguinsContainer, CharactersContainer charactersContainer)
        {
            penguinsContainer.Penguins = new List<Penguin>(_penguinsSettings.penguinsCount);

            for (int i = 0; i < _penguinsSettings.penguinsCount; i++)
            {
                var randomPos = gameField.GetRandomFieldXZPos();
                var position = new Vector3(randomPos.x, 0, randomPos.y);
                var rotation = Quaternion.Euler(0, Random.value * 360, 0);
                var penguin = Object.Instantiate(_penguinsSettings.PenguinPrefab, position, rotation);
                penguin.Init(charactersContainer, _penguinsSettings, gameField);
                penguinsContainer.Penguins.Add(penguin);
            }
        }
    }
}