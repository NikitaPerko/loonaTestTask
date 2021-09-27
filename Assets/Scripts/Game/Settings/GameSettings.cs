using LoonaTest.Game.GameActors;
using UnityEngine;

namespace LoonaTest.Game.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings", order = 1000)]
    public class GameSettings : ScriptableObject
    {
        public PenguinsSettings PenguinsSettings;
        public GameField GameFieldPrefab;
        public CharactersSettings CharactersSettings;
    }
}