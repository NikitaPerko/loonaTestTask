using System;

namespace LoonaTest.Game
{
    public interface ITimeService
    {
        event Action OnSecondUpdate;
        void Init();
        void Update();
    }
}