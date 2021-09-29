using LoonaTest.Game.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoonaTest.Game
{
    public class GameLoader : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
        }
    }
}