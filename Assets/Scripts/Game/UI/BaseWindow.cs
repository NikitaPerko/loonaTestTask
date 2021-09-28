using UnityEngine;

namespace LoonaTest.Game.UI
{
    public abstract class BaseWindow : MonoBehaviour
    {
        protected WindowId Id;
        protected BaseWindowData _baseWindowData;

        public void Init(WindowId windowId, BaseWindowData baseWindowData)
        {
            Id = windowId;
            _baseWindowData = baseWindowData;
        }

        public virtual void OnOpened() { }

        public virtual void OnClosed() { }
    }
}