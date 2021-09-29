using System;
using LoonaTest.Game.Settings;
using VContainer;

namespace LoonaTest.Game
{
    public class GameData
    {
        public int TimeLeft;
        public event Action GameLose;
        public event Action GameWin;

        [Inject]
        public GameData(GameSettings settings)
        {
            TimeLeft = settings.GameTime;
        }

        public void OnGameLose()
        {
            GameLose?.Invoke();
        }

        public void OnGameWin()
        {
            GameWin?.Invoke();
        }
    }
}