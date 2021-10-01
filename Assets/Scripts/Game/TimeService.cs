using System;
using LoonaTest.Game.Settings;
using UnityEngine;
using VContainer;

namespace LoonaTest.Game
{
    public class TimeService : ITimeService
    {
        private readonly GameData _gameData;
        private readonly GameSettings _gameSettings;
        public event Action OnSecondUpdate;

        private int _timePassedInSeconds;
        private float _timePassed;

        [Inject]
        public TimeService(GameData gameData, GameSettings gameSettings)
        {
            _gameData = gameData;
            _gameSettings = gameSettings;
        }

        public void Init()
        {
            _timePassed = 0;
            _timePassedInSeconds = 0;
            _gameData.TimeLeft = _gameSettings.GameTime;
        }

        public void Update()
        {
            _timePassed += Time.deltaTime;

            int timePassedFloor = (int) _timePassed;

            if (timePassedFloor > _timePassedInSeconds)
            {
                _timePassedInSeconds = timePassedFloor;
                _gameData.TimeLeft = _gameSettings.GameTime - _timePassedInSeconds;
                OnSecondUpdate?.Invoke();
            }
        }
    }
}