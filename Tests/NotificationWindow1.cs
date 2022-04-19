using UnityEditor;
using UnityEngine;
using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.Tests
{
    public class NotificationWindow1 : BaseWindow
    {
        private const string PrefabPath = "Assets/UnityGuiManager/Tests/TestResources/TestNotificationWindow1.prefab";
        
        protected override GameObject Prefab => AssetDatabase.LoadAssetAtPath<GameObject>(PrefabPath);
    }
}