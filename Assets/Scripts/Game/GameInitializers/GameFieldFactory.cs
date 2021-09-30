using LoonaTest.Game.GameActors;
using LoonaTest.Game.GameEventHandlers;
using LoonaTest.Game.Settings;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace LoonaTest.Game.GameInitializers
{
    public class GameFieldFactory
    {
        private readonly LifetimeScope _lifetimeScope;
        private readonly GameSettings _gameSettings;
        private readonly GameFieldContainer _gameFieldContainer;

        [Inject]
        public GameFieldFactory(LifetimeScope lifetimeScope, GameSettings gameSettings, GameFieldContainer gameFieldContainer)
        {
            _lifetimeScope = lifetimeScope;
            _gameSettings = gameSettings;
            _gameFieldContainer = gameFieldContainer;
        }

        public void Init()
        {
            var gameField = _lifetimeScope.Container.Instantiate(_gameSettings.GameFieldPrefab);
            _gameFieldContainer.GameField = gameField;
        }
    }
}