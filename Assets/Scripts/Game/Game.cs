using LoonaTest.Game.GameEventHandlers;
using LoonaTest.Game.GameInitializers;
using LoonaTest.Game.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoonaTest.Game
{
    public class Game : MonoBehaviour
    {
        private GameInitializer _gameInitializer;
        private GameEventsHandler _gameEventsHandler;
        private GameSettings _gameSettings;

        public void Init(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            InitDependencies();
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(this);
        }

        private void InitDependencies()
        {
            _gameEventsHandler = new GameEventsHandler();
            _gameInitializer = new GameInitializer(_gameEventsHandler, _gameSettings);
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
            _gameInitializer.Init();
        }
    }
}