using LoonaTest.Game.GameActors;
using LoonaTest.Game.GameEventHandlers;
using LoonaTest.Game.Settings;
using UnityEngine;

namespace LoonaTest.Game.GameInitializers
{
    public class GameFieldInitializer
    {
        private readonly IGameEventsHandler _gameEventsHandler;
        private readonly GameSettings _gameSettings;

        public GameFieldInitializer(IGameEventsHandler gameEventsHandler, GameSettings gameSettings)
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