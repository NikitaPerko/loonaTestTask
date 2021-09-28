using UnityEngine;

namespace LoonaTest.Game.GameEventHandlers
{
    public class PenguinsAreOverHandler : IPenguinsAreOverHandler
    {
        private readonly GameData _gameData;

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