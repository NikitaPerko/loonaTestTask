using UnityEngine;

namespace LoonaTest.Game.UI
{
    public abstract class BaseWindow : MonoBehaviour
    {
        protected WindowId Id;
        protected BaseWindowData BaseWindowData;

        public void Init(WindowId windowId, BaseWindowData baseWindowData)
        {
            Id = windowId;
            BaseWindowData = baseWindowData;
        }

        public virtual void OnOpened() { }

        public virtual void OnClosed() { }
    }
}