using System;
using System.Collections.Generic;
using LoonaTest.Game.UI;
using UnityEngine;

namespace LoonaTest.Game.Settings
{
    [CreateAssetMenu(fileName = "WindowsSettings", menuName = "Settings/WindowsSettings", order = 1000)]
    public class WindowsSettings : ScriptableObject
    {
        public List<WindowReference> windowPrefabs;
    }

    [Serializable]
    public class WindowReference
    {
        public WindowId Id;
        public BaseWindow WindowPrefab;
    }
}