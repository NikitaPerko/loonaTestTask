using UnityEngine;

namespace LoonaTest.Game.Settings
{
    [CreateAssetMenu(fileName = "PenguinsSettings", menuName = "Settings/PenguinsSettings", order = 1000)]
    public class PenguinsSettings : ScriptableObject
    {
        public Penguin PenguinPrefab;
        public int penguinsCount;
        public float dangerRadius;
        public float idleWaitingTimeFrom;
        public float idleWaitingTimeTo;
        public float idleWalkingSpeedFrom;
        public float idleWalkingSpeedTo;

        public float DangerRadiusSqr => dangerRadius * dangerRadius;
    }
}