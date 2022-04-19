using System.Collections.Generic;
using UnityEngine;
using UnityGuiManager.Runtime.Contexts;
using UnityGuiManager.Runtime.Layers;
using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.Runtime
{
    public class GuiManager
    {
        private readonly List<GuiLayer> _layers = new List<GuiLayer>();
        private readonly List<GuiContext> _contexts = new List<GuiContext>();
        
        public Transform Root
        {
            get;
        }

        internal GuiManagerConfig Config
        {
            get;
        }

        private GuiManager()
        {
            
        }

        public GuiManager(GuiManagerConfig config) : this()
        {
            Config = config;
            Root = new GameObject("GuiManager").transform;
        }
    
        public GuiManager(GuiManagerConfig config, Transform root) : this()
        {
            Config = config;
            Root = root;

            foreach (Transform layer in Root)
            {
                AddLayer(layer);
            }
        }

        public IGuiContext AddContext()
        {
            var context = new GuiContext(_contexts.Count, this);
            _contexts.Add(context);
            return context;
        }

        public void AddLayer()
        {
            _layers.Add(new GuiLayer(_layers.Count, Config, Root));
        }
        
        public void AddLayer(Transform layer)
        {
            _layers.Add(new GuiLayer(_layers.Count, layer));
        }

        public IGuiLayer GetLayer(int index)
        {
            return _layers[index];
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