using System.Collections.Generic;
using UnityEngine;

namespace UnityGuiManager.Runtime
{
    public class GuiManager
    {
        private readonly List<GuiLayer> _layers = new List<GuiLayer>();
        
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

        public void AddLayer()
        {
            _layers.Add(new GuiLayer(_layers.Count, this));
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