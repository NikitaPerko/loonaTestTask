using UnityEngine;
using VContainer;

namespace LoonaTest.Game.GameEventHandlers
{
    public class TimeIsOverHandler : ITimeIsOverHandler
    {
        private readonly GameData _gameData;

        [Inject]
        public TimeIsOverHandler(GameData gameData)
        {
            _gameData = gameData;
        }

        public void OnTimeIsOver()
        {
            _gameData.OnGameLose();
            Time.timeScale = 0;
        }
    }
}