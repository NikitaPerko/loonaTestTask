using LoonaTest.Game.GameEventHandlers;
using LoonaTest.Game.Settings;

namespace LoonaTest.Game
{
    public class TimeIsOverService
    {
        private readonly ITimeService _timeService;
        private readonly GameData _gameData;
        private readonly IGameEventsHandler _gameEventsHandler;

        public TimeIsOverService(ITimeService timeService, GameData gameData, IGameEventsHandler gameEventsHandler)
        {
            _timeService = timeService;
            _gameData = gameData;
            _gameEventsHandler = gameEventsHandler;
        }

        public void Init()
        {
            _timeService.OnSecondUpdate += OnSecondUpdate;
        }

        private void OnSecondUpdate()
        {
            if (_gameData.TimeLeft <= 0)
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