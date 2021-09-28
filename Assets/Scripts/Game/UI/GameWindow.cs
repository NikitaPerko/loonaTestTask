using LoonaTest.Game.UI;
using TMPro;
using UnityEngine;

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

        private GameWindowData _windowData;

        public override void OnOpened()
        {
            _windowData = (GameWindowData) _baseWindowData;
            _timer.text = _windowData.GameData.TimeLeft.ToString();
            _youLoseLabel.SetActive(false);
            _youWinLabel.SetActive(false);
            _resetButton.SetActive(false);
            _windowData.GameData.GameWin += OnWin;
            _windowData.GameData.GameLose += OnLose;
            _windowData.TimeService.OnSecondUpdate += OnSecondUpdate;
        }

        private void OnSecondUpdate()
        {
            _timer.text = _windowData.GameData.TimeLeft.ToString();
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
            _windowData.GameData.GameWin -= OnWin;
            _windowData.GameData.GameLose -= OnLose;
            _windowData.TimeService.OnSecondUpdate -= OnSecondUpdate;
        }

        public void OnResetClicked()
        {
            _windowData.UIManager.Close(Id);
            _windowData.Game.RestartGame();
        }
    }

    public class GameWindowData : BaseWindowData
    {
        public GameData GameData;
        public ITimeService TimeService;
        public Game Game;
        public UIManager UIManager;
    }
}