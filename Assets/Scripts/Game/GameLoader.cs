using LoonaTest.Game.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoonaTest.Game
{
    public class GameLoader : MonoBehaviour
    {
        [SerializeField]
        private GameSettings _gameSettings;

        private void Start()
        {
            var gameController = new GameObject().AddComponent<Game>();
            gameController.name = "GameController";
            gameController.Init(_gameSettings);

            SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
        }
    }
}