using LoonaTest.Game.GameActors.Characters;
using UnityEngine;

namespace LoonaTest.Game.Settings
{
    [CreateAssetMenu(fileName = "CharactersSettings", menuName = "Settings/CharactersSettings", order = 1000)]
    public class CharactersSettings : ScriptableObject
    {
        public float Speed;
        public Character Prefab;
        public int PlayersCount;
    }
}