using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using UnityGuiManager.Runtime;

namespace UnityGuiManager.Tests
{
    public class PlayModeTests
    {
        private const string ConfigPath = "Assets/UnityGuiManager/Tests/TestResources/TestsGuiManagerConfig.asset";
        private const string ReadyGuiManagerPath = "Assets/UnityGuiManager/Tests/TestResources/TestsGuiManager.prefab";

        [UnityTest]
        public IEnumerator CreateGuiManagerTest()
        {
            yield return null;

            var config = AssetDatabase.LoadAssetAtPath<GuiManagerConfig>(ConfigPath);
            
            var guiManager = new GuiManager(config);
            
            Assert.NotNull(guiManager.Root, null);
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

            Assert.AreNotEqual(guiManager.GetLayer(0), null);
            Assert.AreNotEqual(guiManager.GetLayer(1), null);
        }
    }
}
