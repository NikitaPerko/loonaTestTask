using LoonaTest.Game.GameActors;
using LoonaTest.Game.GameActors.Characters;
using LoonaTest.Game.GameActors.Penguins;
using LoonaTest.Game.GameEventHandlers;
using LoonaTest.Game.GameInitializers;
using LoonaTest.Game.Settings;
using LoonaTest.Game.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoonaTest.Game
{
    public class Game : MonoBehaviour
    {
        private GameData _gameData;
        private IGameEventsHandler _gameEventsHandler;
        private GameSettings _gameSettings;
        private GameFieldInitializer _gameFieldInitializer;
        private PenguinsInitializer _penguinsInitializer;
        private CharactersInitializer _charactersInitializer;
        private PenguinsDeinitializer _penguinsDeinitializer;
        private CharactersDeinitializer _charactersDeinitializer;
        private CharactersContainer _charactersContainer;
        private PenguinsContainer _penguinsContainer;
        private GameFieldDeinitializer _gameFieldDeinitializer;
        private GameField _gameField;
        private ITimeService _timeService;
        private TimeIsOverService _timeIsOverService;
        private UIManager _uiManager;

        public void Init(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            InitDependencies();
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(this);
        }

        private void InitDependencies()
        {
            _gameData = new GameData(_gameSettings);
            _gameEventsHandler = new GameEventsHandler();
            _timeService = new TimeService(_gameData, _gameSettings);
            _gameFieldInitializer = new GameFieldInitializer(_gameEventsHandler, _gameSettings);
            _penguinsInitializer = new PenguinsInitializer(_gameSettings.PenguinsSettings);
            _charactersInitializer = new CharactersInitializer(_gameSettings.CharactersSettings);
            _charactersContainer = new CharactersContainer();
            _penguinsContainer = new PenguinsContainer();
            _penguinsDeinitializer = new PenguinsDeinitializer(_penguinsContainer);
            _charactersDeinitializer = new CharactersDeinitializer(_charactersContainer);
            _timeIsOverService = new TimeIsOverService(_timeService, _gameData, _gameEventsHandler);
        }

        private void DeinitDependencies()
        {
            _gameData = null;
            _gameEventsHandler = null;
            _timeService = null;
            _gameFieldInitializer = null;
            _penguinsInitializer = null;
            _charactersInitializer = null;
            _charactersContainer = null;
            _penguinsContainer = null;
            _gameFieldDeinitializer = null;
            _penguinsDeinitializer = null;
            _charactersDeinitializer = null;
            _timeIsOverService = null;
            _gameField = null;
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
            Time.timeScale = 1;
            _uiManager = new UIManager(_gameSettings.WindowsSettings);
            _timeService.Init();
            _timeIsOverService.Init();
            _gameField = _gameFieldInitializer.Init();
            _gameFieldDeinitializer = new GameFieldDeinitializer(_gameField);
            _penguinsInitializer.Init(_gameField, _penguinsContainer, _charactersContainer);
            _charactersInitializer.Init(_gameField, _charactersContainer, _penguinsContainer);
            _gameEventsHandler.SetDependencies(_penguinsContainer, this, _gameData);

            _uiManager.Open<GameWindow>(WindowId.GameWindow,
                new GameWindowData() {GameData = _gameData, TimeService = _timeService, Game = this, UIManager = _uiManager});
        }

        private void DeinitGame()
        {
            _gameFieldDeinitializer.Deinit();
            _penguinsDeinitializer.Deinit();
            _charactersDeinitializer.Deinit();
            _timeIsOverService.Deinit();
            DeinitDependencies();
        }

        public void RestartGame()
        {
            DeinitGame();
            InitDependencies();
            InitGame();
        }

        private void Update()
        {
            _timeService?.Update();
        }
    }
}