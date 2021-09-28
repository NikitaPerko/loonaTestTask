using LoonaTest.Game.Settings;
using UnityEngine;

namespace LoonaTest.Game.UI
{
    public class WindowsFactory
    {
        private readonly WindowsSettings _windowsSettings;
        private readonly RectTransform _mainCanvas;

        public WindowsFactory(WindowsSettings windowsSettings, RectTransform mainCanvas)
        {
            _windowsSettings = windowsSettings;
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