using LoonaTest.Game.Settings;
using UnityEngine;
using VContainer;

namespace LoonaTest.Game.UI
{
    public class WindowsFactory
    {
        private readonly WindowsSettings _windowsSettings;
        private RectTransform _mainCanvas;

        [Inject]
        public WindowsFactory(WindowsSettings windowsSettings)
        {
            _windowsSettings = windowsSettings;
        }

        public void Init(RectTransform mainCanvas)
        {
            _mainCanvas = mainCanvas;
        }

        public BaseWindow Create(WindowId id)
        {
            var windowSettings = _windowsSettings.windowPrefabs.Find(x => x.Id == id);
            var window = Object.Instantiate(windowSettings.WindowPrefab, _mainCanvas);
            return window;
        }
    }
}