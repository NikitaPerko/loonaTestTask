using LoonaTest.Game.GameActors;
using UnityEngine;
using VContainer;

namespace LoonaTest.Game.GameDeinitializers
{
    public class GameFieldDeinitializer
    {
        private readonly GameFieldContainer _gameFieldContainer;

        [Inject]
        public GameFieldDeinitializer(GameFieldContainer gameFieldContainer)
        {
            _gameFieldContainer = gameFieldContainer;
        }

        public void Deinit()
        {
            Object.Destroy(_gameFieldContainer.GameField.gameObject);
        }
    }
}