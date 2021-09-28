using System;
using UnityEngine;

namespace LoonaTest.Game
{
    public class TimeService : ITimeService
    {
        private readonly GameData _gameData;
        public event Action OnSecondUpdate;

        private float initTime;

        public TimeService(GameData gameData)
        {
            _gameData = gameData;
        }

        public void Init()
        {
            initTime = Time.realtimeSinceStartup;
        }

        public void Update()
        {
            float timePassed = Time.realtimeSinceStartup - initTime;

            if ((int) timePassed > _gameData.Time)
            {
                _gameData.Time = (int) timePassed;
                OnSecondUpdate?.Invoke();
            }
        }
    }
}