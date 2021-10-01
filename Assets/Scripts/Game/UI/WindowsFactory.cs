using LoonaTest.Game.Settings;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace LoonaTest.Game.UI
{
    public class WindowsFactory
    {
        private readonly LifetimeScope _container;
        private readonly WindowsSettings _windowsSettings;
        private RectTransform _mainCanvas;

        [Inject]
        public WindowsFactory(LifetimeScope container, WindowsSettings windowsSettings)
        {
            _container = container;
            _windowsSettings = windowsSettings;
        }

        public void Init(RectTransform mainCanvas)
        {
            _mainCanvas = mainCanvas;
        }

        public BaseWindow Create(WindowId id)
        {
            var windowSettings = _windowsSettings.windowPrefabs.Find(x => x.Id == id);
            var window = _container.Container.Instantiate(windowSettings.WindowPrefab, _mainCanvas);
            return window;
        }
    }
}