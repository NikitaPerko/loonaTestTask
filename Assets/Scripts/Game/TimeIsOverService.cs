using LoonaTest.Game.GameEventHandlers;
using LoonaTest.Game.Settings;

namespace LoonaTest.Game
{
    public class TimeIsOverService
    {
        private readonly ITimeService _timeService;
        private readonly GameData _gameData;
        private readonly IGameEventsHandler _gameEventsHandler;
        private readonly GameSettings _gameSettings;

        public TimeIsOverService(ITimeService timeService, GameData gameData, IGameEventsHandler gameEventsHandler,
            GameSettings gameSettings)
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