using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using UnityGuiManager.Runtime;
using UnityGuiManager.Runtime.Windows;
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

        [UnityTest]
        public IEnumerator OpenCloseWindowsTest()
        {
            yield return null;
            
            var config = AssetDatabase.LoadAssetAtPath<GuiManagerConfig>(ConfigPath);
            
            var guiManager = new GuiManager(config);
            guiManager.AddLayer();
            guiManager.AddContext();

            var viewMapper = new StringKeyGameObjectMapper();
            viewMapper.Set("TestNotificationWindow1",  AssetDatabase.LoadAssetAtPath<GameObject>(NotificationWindow1PrefabPath));
            viewMapper.Set("TestNotificationWindow2",  AssetDatabase.LoadAssetAtPath<GameObject>(NotificationWindow2PrefabPath));
            
            guiManager.SetViewMapper(viewMapper);

            var window = guiManager.CurrentContext.Open<NotificationWindow1>("TestNotificationWindow1");
            
            yield return null;
            
            Assert.NotNull(window);
            Assert.AreEqual(guiManager.CurrentContext.GetLast().Status, WindowStatus.Opened);
            
            yield return new WaitForSeconds(15f);
            
            guiManager.CurrentContext.CloseLast();
            
            Assert.Null(guiManager.CurrentContext.GetLast());
            
        }
    }
}
