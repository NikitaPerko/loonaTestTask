using LoonaTest.Game.GameDeinitializers;
using LoonaTest.Game.GameInitializers;
using LoonaTest.Game.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace LoonaTest.Game
{
    public class Game : IStartable, ITickable
    {
        private readonly GameFieldFactory _gameFieldFactory;
        private readonly PenguinsInitializer _penguinsInitializer;
        private readonly CharactersInitializer _charactersInitializer;
        private readonly PenguinsDeinitializer _penguinsDeinitializer;
        private readonly CharactersDeinitializer _charactersDeinitializer;
        private readonly GameFieldDeinitializer _gameFieldDeinitializer;
        private readonly ITimeService _timeService;
        private readonly TimeIsOverService _timeIsOverService;
        private readonly UIManager _uiManager;

        [Inject]
        public Game(GameFieldFactory gameFieldFactory, PenguinsInitializer penguinsInitializer,
            CharactersInitializer charactersInitializer, PenguinsDeinitializer penguinsDeinitializer,
            CharactersDeinitializer charactersDeinitializer, GameFieldDeinitializer gameFieldDeinitializer,
            ITimeService timeService, TimeIsOverService timeIsOverService, UIManager uiManager)
        {
            _gameFieldFactory = gameFieldFactory;
            _penguinsInitializer = penguinsInitializer;
            _charactersInitializer = charactersInitializer;
            _penguinsDeinitializer = penguinsDeinitializer;
            _charactersDeinitializer = charactersDeinitializer;
            _gameFieldDeinitializer = gameFieldDeinitializer;
            _timeService = timeService;
            _timeIsOverService = timeIsOverService;
            _uiManager = uiManager;
        }

        public void Start()
        {
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
            Time.timeScale = 1;
            _timeService.Init();
            _timeIsOverService.Init();
            _gameFieldFactory.Init();
            _penguinsInitializer.Init();
            _charactersInitializer.Init();

            _uiManager.Init();

            _uiManager.Open<GameWindow>(WindowId.GameWindow);
        }

        private void DeinitGame()
        {
            _gameFieldDeinitializer.Deinit();
            _penguinsDeinitializer.Deinit();
            _charactersDeinitializer.Deinit();
            _timeIsOverService.Deinit();
        }

        public void RestartGame()
        {
            DeinitGame();
            InitGame();
        }

        public void Tick()
        {
            _timeService?.Update();
        }
    }
}