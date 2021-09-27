using System.Collections.Generic;
using LoonaTest.Game.GameEventHandlers;
using LoonaTest.Game.Settings;

namespace LoonaTest.Game.GameInitializers
{
    public class GameInitializer
    {
        private readonly GameSettings _gameSettings;
        private readonly GameFieldInitializer _gameFieldInitializer;
        private readonly PenguinsInitializer _penguinsInitializer;

        public GameInitializer(GameEventsHandler gameEventsHandler, GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _gameFieldInitializer = new GameFieldInitializer(gameEventsHandler, gameSettings);
            _penguinsInitializer = new PenguinsInitializer(gameSettings.PenguinsSettings);
        }

        public void Init()
        {
            var gameField = _gameFieldInitializer.Init();
            var penguins = _penguinsInitializer.Init(gameField);
            penguins.ForEach(x=>x.Init(new List<Character>(), _gameSettings.PenguinsSettings,gameField ));
        }
    }
}