using LoonaTest.Game.GameEventHandlers;
using LoonaTest.Game.Settings;
using VContainer;

namespace LoonaTest.Game
{
    public class TimeIsOverService
    {
        private readonly ITimeService _timeService;
        private readonly GameData _gameData;
        private readonly ITimeIsOverHandler _timeIsOverHandler;

        [Inject]
        public TimeIsOverService(ITimeService timeService, GameData gameData, ITimeIsOverHandler timeIsOverHandler)
        {
            _timeService = timeService;
            _gameData = gameData;
            _timeIsOverHandler = timeIsOverHandler;
        }

        public void Init()
        {
            _timeService.OnSecondUpdate += OnSecondUpdate;
        }

        private void OnSecondUpdate()
        {
            if (_gameData.TimeLeft <= 0)
            {
                _timeIsOverHandler.OnTimeIsOver();
            }
        }

        public void Deinit()
        {
            _timeService.OnSecondUpdate -= OnSecondUpdate;
        }
    }
}