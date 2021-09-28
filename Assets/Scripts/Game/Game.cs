using System;
using LoonaTest.Game.GameActors;
using LoonaTest.Game.GameActors.Characters;
using LoonaTest.Game.GameActors.Penguins;
using LoonaTest.Game.GameEventHandlers;
using LoonaTest.Game.GameInitializers;
using LoonaTest.Game.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoonaTest.Game
{
    public class Game : MonoBehaviour
    {
        private GameData _gameData;
        private GameEventsHandler _gameEventsHandler;
        private GameSettings _gameSettings;
        private GameFieldInitializer _gameFieldInitializer;
        private PenguinsInitializer _penguinsInitializer;
        private CharactersInitializer _charactersInitializer;
        private CharactersContainer _charactersContainer;
        private PenguinsContainer _penguinsContainer;
        private GameField _gameField;
        private TimeService _timeService;
        private TimeIsOverService _timeIsOverService;

        public void Init(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            InitDependencies();
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(this);
        }

        private void InitDependencies()
        {
            _gameData = new GameData();
            _gameEventsHandler = new GameEventsHandler();
            _timeService = new TimeService(_gameData);
            _gameFieldInitializer = new GameFieldInitializer(_gameEventsHandler, _gameSettings);
            _penguinsInitializer = new PenguinsInitializer(_gameSettings.PenguinsSettings);
            _charactersInitializer = new CharactersInitializer(_gameSettings.CharactersSettings);
            _charactersContainer = new CharactersContainer();
            _penguinsContainer = new PenguinsContainer();
            _timeIsOverService = new TimeIsOverService(_timeService, _gameData, _gameEventsHandler, _gameSettings);
        }

        private void DeinitDependencies()
        {
            _timeService = null;
            _gameEventsHandler = null;
            _gameFieldInitializer = null;
            _penguinsInitializer = null;
            _charactersInitializer = null;
            _charactersContainer = null;
            _penguinsContainer = null;
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
            _timeService.Init();
            _timeIsOverService.Init();
            _gameField = _gameFieldInitializer.Init();
            _penguinsInitializer.Init(_gameField, _penguinsContainer, _charactersContainer);
            _charactersInitializer.Init(_gameField, _charactersContainer, _penguinsContainer);
            _gameEventsHandler.SetDependencies(_penguinsContainer, this);
        }

        public void DeinitGame()
        {
            Destroy(_gameField.gameObject);
            _gameField = null;

            foreach (var penguin in _penguinsContainer.Penguins)
            {
                penguin.Deinit();
                Destroy(penguin.gameObject);
            }

            _penguinsContainer.Penguins.Clear();

            foreach (var character in _charactersContainer.Characters)
            {
                Destroy(character.gameObject);
            }

            _charactersContainer.Characters.Clear();
            _timeIsOverService.Deinit();
            DeinitDependencies();
        }

        public void RestartGame()
        {
            InitDependencies();
            InitGame();
        }

        private void Update()
        {
            _timeService?.Update();
        }
    }
}