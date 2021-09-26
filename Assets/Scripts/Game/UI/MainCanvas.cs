using UnityEngine;

namespace LoonaTest.Game.UI
{
    public class MainCanvas : MonoBehaviour
    {
        public void Construct(IUIManager uiManager)
        {
            uiManager.SetupCanvas((RectTransform) transform);
        }
    }
}