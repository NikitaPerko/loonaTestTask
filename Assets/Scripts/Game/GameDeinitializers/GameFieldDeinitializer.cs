using LoonaTest.Game.GameActors;
using UnityEngine;

namespace LoonaTest.Game
{
    public class GameFieldDeinitializer
    {
        private readonly GameField _gameField;

        public GameFieldDeinitializer(GameField gameField)
        {
            _gameField = gameField;
        }

        public void Deinit()
        {
            Object.Destroy(_gameField.gameObject);
        }
    }
}