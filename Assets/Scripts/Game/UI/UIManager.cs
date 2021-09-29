using System;
using System.Collections.Generic;
using LoonaTest.Game.Settings;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

namespace LoonaTest.Game.UI
{
    public class UIManager
    {
        private readonly WindowsFactory _windowsFactory;
        private Dictionary<WindowId, BaseWindow> _openedWindows;

        [Inject]
        public UIManager(WindowsFactory windowsFactory)
        {
            _windowsFactory = windowsFactory;
            _openedWindows = new Dictionary<WindowId, BaseWindow>();
        }

        public void Init()
        {
            var mainCanvas = (RectTransform) Object.FindObjectOfType<MainCanvas>().transform;
            _windowsFactory.Init(mainCanvas);
        }

        public BaseWindow Open(WindowId windowId)
        {
            if (!_openedWindows.ContainsKey(windowId))
            {
                var window = _windowsFactory.Create(windowId);
                window.OnOpened();
                _openedWindows.Add(windowId, window);
                return window;
            }

            throw new Exception($"Window with id = {windowId} has been already opened");
        }

        public T Open<T>(WindowId windowId, BaseWindowData windowData = null) where T : BaseWindow
        {
            if (!_openedWindows.ContainsKey(windowId))
            {
                var window = _windowsFactory.Create(windowId);
                window.Init(windowId, windowData);
                window.OnOpened();
                _openedWindows.Add(windowId, window);
                return (T) window;
            }

            throw new Exception($"Window with id = {windowId} has been already opened");
        }

        public void Close(WindowId windowId)
        {
            if (_openedWindows.ContainsKey(windowId))
            {
                var window = _openedWindows[windowId];
                window.OnClosed();
                _openedWindows.Remove(windowId);
                Object.Destroy(window.gameObject);
            }
        }
    }
}