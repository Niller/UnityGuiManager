using UnityEditor;
using UnityEngine;
using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.Tests
{
    public class NotificationWindow2 : BaseWindow
    {
        private const string PrefabPath = "Assets/UnityGuiManager/Tests/TestResources/TestNotificationWindow2.prefab";
        
        protected override GameObject Prefab => AssetDatabase.LoadAssetAtPath<GameObject>(PrefabPath);
    }
}