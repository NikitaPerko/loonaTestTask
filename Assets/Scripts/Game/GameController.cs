using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoonaTest.Game
{
    public class GameController : MonoBehaviour
    {
        private GameFieldInitializer _gameFieldInitializer;

        private void Start()
        {
            DontDestroyOnLoad(this);
            _gameFieldInitializer = new GameFieldInitializer();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode _)
        {
            if (scene.name == "Game")
            {
                InitGame();
            }
        }

        private void InitGame()
        {
            _gameFieldInitializer.Init();
        }
    }
}