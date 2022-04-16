using UnityEngine;

namespace UnityGuiManager.Runtime
{
    public class GuiManager 
    {
        public Transform Root
        {
            get;
        }

        internal GuiManagerConfig Config
        {
            get;
        }

        public GuiManager(GuiManagerConfig config)
        {
            Config = config;
            Root = new GameObject("GuiManager").transform;
        }
    
        public GuiManager(GuiManagerConfig config, Transform root)
        {
            Config = config;
            Root = root;
        }

        internal void Close(BaseWindow window)
        {
            window.Layer.Remove(window);
        }

        public void CloseLast()
        {
        
        }

        public void CloseAll()
        {
        
        }
    }
}