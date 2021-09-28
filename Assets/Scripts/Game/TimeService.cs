using System;
using LoonaTest.Game.Settings;
using UnityEngine;

namespace LoonaTest.Game
{
    public class TimeService : ITimeService
    {
        private readonly GameData _gameData;
        private readonly GameSettings _gameSettings;
        public event Action OnSecondUpdate;

        private int initTime;
        private int currentTime;

        public TimeService(GameData gameData, GameSettings gameSettings)
        {
            _gameData = gameData;
            _gameSettings = gameSettings;
        }

        public void Init()
        {
            initTime = (int) Time.timeSinceLevelLoad;
            currentTime = initTime;
        }

        public void Update()
        {
            int timePassed = (int) Time.timeSinceLevelLoad - initTime;

            if (timePassed > currentTime)
            {
                currentTime = timePassed;
                _gameData.TimeLeft = _gameSettings.GameTime - timePassed;
                OnSecondUpdate?.Invoke();
            }
        }
    }
}