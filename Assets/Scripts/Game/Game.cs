using System;
using System.Collections.Generic;
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
        private GameEventsHandler _gameEventsHandler;
        private GameSettings _gameSettings;
        private GameFieldInitializer _gameFieldInitializer;
        private PenguinsInitializer _penguinsInitializer;
        private CharactersInitializer _charactersInitializer;

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
            _gameFieldInitializer = new GameFieldInitializer(_gameEventsHandler, _gameSettings);
            _penguinsInitializer = new PenguinsInitializer(_gameSettings.PenguinsSettings);
            _charactersInitializer = new CharactersInitializer(_gameSettings.CharactersSettings);
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
            var charactersContainer = new CharactersContainer();
            var penguinsContainer = new PenguinsContainer();
            var gameField = _gameFieldInitializer.Init();
            _penguinsInitializer.Init(gameField, penguinsContainer, charactersContainer);
            _charactersInitializer.Init(gameField, charactersContainer, penguinsContainer);
            _gameEventsHandler.SetDependencies(penguinsContainer);
        }
    }
}