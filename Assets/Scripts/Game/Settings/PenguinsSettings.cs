using UnityEngine;

namespace LoonaTest.Game.Settings
{
    [CreateAssetMenu(fileName = "PenguinsSettings", menuName = "Settings/PenguinsSettings", order = 1000)]
    public class PenguinsSettings : ScriptableObject
    {
        public Penguin PenguinPrefab;
        public int penguinsCount;
    }
}