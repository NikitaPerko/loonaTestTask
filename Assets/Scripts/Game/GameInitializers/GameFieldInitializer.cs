using LoonaTest.Game.GameActors;
using LoonaTest.Game.GameEventHandlers;
using LoonaTest.Game.Settings;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace LoonaTest.Game.GameInitializers
{
    public class GameFieldInitializer
    {
        private readonly GameSettings _gameSettings;
        private readonly GameFieldContainer _gameFieldContainer;

        [Inject]
        public GameFieldInitializer(GameSettings gameSettings, GameFieldContainer gameFieldContainer)
        {
            _gameSettings = gameSettings;
            _gameFieldContainer = gameFieldContainer;
        }

        public void Init()
        {
            var gameField = Object.Instantiate(_gameSettings.GameFieldPrefab);
            gameField.Init();
            _gameFieldContainer.GameField = gameField;
        }
    }
}