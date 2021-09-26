using UnityEngine;

namespace LoonaTest.Game
{
    public class GameFieldInitializer
    {
        private readonly GameField _gameFieldPrefab;

        public GameFieldInitializer()
        {
            _gameFieldPrefab = Resources.Load<GameField>("GameField");
        }

        public GameField Init()
        {
            var gameField = Object.Instantiate(_gameFieldPrefab);
            gameField.Init();
            return gameField;
        }
    }
}