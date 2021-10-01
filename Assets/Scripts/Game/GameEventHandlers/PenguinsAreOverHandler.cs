using UnityEngine;
using VContainer;

namespace LoonaTest.Game.GameEventHandlers
{
    public class PenguinsAreOverHandler : IPenguinsAreOverHandler
    {
        private readonly GameData _gameData;

        [Inject]
        public PenguinsAreOverHandler(GameData gameData)
        {
            _gameData = gameData;
        }

        public void OnPenguinsAreOver()
        {
            _gameData.OnGameWin();
            Time.timeScale = 0;
        }
    }
}