using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TestTools;
using UnityGuiManager.Runtime;
using UnityGuiManager.TestsScripts;

namespace UnityGuiManager.Tests
{
    public class PlayModeTests
    {
        private const string TestsResourcesPath = "Assets/UnityGuiManager/Tests/TestResources/";
        
        private const string ConfigPath = TestsResourcesPath + "TestsGuiManagerConfig.asset";
        private const string ReadyGuiManagerPath = TestsResourcesPath + "TestsGuiManager.prefab";
        
        private const string NotificationWindow1PrefabPath = TestsResourcesPath + "TestNotificationWindow1.prefab";
        private const string NotificationWindow2PrefabPath = TestsResourcesPath + "TestNotificationWindow2.prefab";

        [UnityTest]
        public IEnumerator CreateGuiManagerTest()
        {
            yield return null;

            var config = AssetDatabase.LoadAssetAtPath<GuiManagerConfig>(ConfigPath);
            
            var guiManager = new GuiManager(config);
            
            Assert.NotNull(guiManager.Root);
        }
        
        [UnityTest]
        public IEnumerator CreateLayerTest()
        {
            yield return null;

            var config = AssetDatabase.LoadAssetAtPath<GuiManagerConfig>(ConfigPath);
            
            var guiManager = new GuiManager(config);
            guiManager.AddLayer();
            guiManager.AddLayer();
            
            Assert.AreEqual(guiManager.Root.childCount, 2);
        }
        
        [UnityTest]
        public IEnumerator LoadLayerTest()
        {
            yield return null;

            var config = AssetDatabase.LoadAssetAtPath<GuiManagerConfig>(ConfigPath);
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(ReadyGuiManagerPath);

            var instance = Object.Instantiate(prefab);
            
            var guiManager = new GuiManager(config, instance.transform);

            Assert.NotNull(guiManager.GetLayer(0));
            Assert.NotNull(guiManager.GetLayer(1));
        }

        public IEnumerator OpenCloseWindowsTest()
        {
            yield return null;
            
            var config = AssetDatabase.LoadAssetAtPath<GuiManagerConfig>(ConfigPath);
            
            var guiManager = new GuiManager(config);
            guiManager.AddLayer();
            guiManager.AddContext();
            
            var window = guiManager.CurrentContext.Open<NotificationWindow1>();
            
            Assert.NotNull(window);
            Assert.AreEqual(guiManager.CurrentContext.GetLast().GetType(), typeof(NotificationWindow1));
            
            guiManager.CurrentContext.CloseLast();
            
            Assert.Null(guiManager.CurrentContext.GetLast());
            
        }
    }
}
