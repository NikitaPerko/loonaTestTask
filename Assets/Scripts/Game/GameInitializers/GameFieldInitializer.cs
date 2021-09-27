using LoonaTest.Game.GameEventHandlers;
using LoonaTest.Game.Settings;
using UnityEngine;

namespace LoonaTest.Game.GameInitializers
{
    public class GameFieldInitializer
    {
        private readonly GameEventsHandler _gameEventsHandler;
        private readonly GameSettings _gameSettings;

        public GameFieldInitializer(GameEventsHandler gameEventsHandler, GameSettings gameSettings)
        {
            _gameEventsHandler = gameEventsHandler;
            _gameSettings = gameSettings;
        }

        public GameField Init()
        {
            var gameField = Object.Instantiate(_gameSettings.GameFieldPrefab);
            gameField.Init(_gameEventsHandler);
            return gameField;
        }
    }
}