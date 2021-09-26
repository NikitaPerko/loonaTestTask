using UnityEngine;

namespace LoonaTest.Game.UI
{
    public class UIManager : IUIManager
    {
        private RectTransform _canvasTrasform;
        public UIManager() { }

        public void SetupCanvas(RectTransform canvas)
        {
            _canvasTrasform = canvas;
        }
    }
}