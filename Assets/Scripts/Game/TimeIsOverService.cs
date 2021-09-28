using LoonaTest.Game.GameEventHandlers;
using LoonaTest.Game.Settings;

namespace LoonaTest.Game
{
    public class TimeIsOverService
    {
        private readonly TimeService _timeService;
        private readonly GameData _gameData;
        private readonly GameEventsHandler _gameEventsHandler;
        private readonly GameSettings _gameSettings;

        public TimeIsOverService(TimeService timeService, GameData gameData, GameEventsHandler gameEventsHandler, GameSettings gameSettings)
        {
            _timeService = timeService;
            _gameData = gameData;
            _gameEventsHandler = gameEventsHandler;
            _gameSettings = gameSettings;
        }

        public void Init()
        {
            _timeService.OnSecondUpdate += OnSecondUpdate;
        }

        private void OnSecondUpdate()
        {
            if (_gameData.Time >= _gameSettings.GameTime)
            {
                _gameEventsHandler.OnTimeIsOver();
            }
        }

        public void Deinit()
        {
            _timeService.OnSecondUpdate -= OnSecondUpdate;
        }
    }
}