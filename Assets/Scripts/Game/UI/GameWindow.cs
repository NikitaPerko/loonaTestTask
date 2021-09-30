using JetBrains.Annotations;
using LoonaTest.Game.UI;
using TMPro;
using UnityEngine;
using VContainer;

namespace LoonaTest.Game
{
    public class GameWindow : BaseWindow
    {
        [SerializeField]
        private TextMeshProUGUI _timer;

        [SerializeField]
        private GameObject _youLoseLabel;

        [SerializeField]
        private GameObject _youWinLabel;

        [SerializeField]
        private GameObject _resetButton;

        private GameData _gameData;
        private ITimeService _timeService;
        private Game _game;
        private UIManager _uiManager;

        [Inject, UsedImplicitly]
        public void Construct(GameData gameData, ITimeService timeService, Game game, UIManager uiManager)
        {
            _uiManager = uiManager;
            _game = game;
            _timeService = timeService;
            _gameData = gameData;
        }

        public override void OnOpened()
        {
            _timer.text = _gameData.TimeLeft.ToString();
            _youLoseLabel.SetActive(false);
            _youWinLabel.SetActive(false);
            _resetButton.SetActive(false);
            _gameData.GameWin += OnWin;
            _gameData.GameLose += OnLose;
            _timeService.OnSecondUpdate += OnSecondUpdate;
        }

        private void OnSecondUpdate()
        {
            _timer.text = _gameData.TimeLeft.ToString();
        }

        private void OnLose()
        {
            _youLoseLabel.SetActive(true);
            _resetButton.SetActive(true);
        }

        private void OnWin()
        {
            _youWinLabel.SetActive(true);
            _resetButton.SetActive(true);
        }

        public override void OnClosed()
        {
            _gameData.GameWin -= OnWin;
            _gameData.GameLose -= OnLose;
            _timeService.OnSecondUpdate -= OnSecondUpdate;
        }

        public void OnResetClicked()
        {
            _uiManager.Close(Id);
            _game.RestartGame();
        }
    }
}