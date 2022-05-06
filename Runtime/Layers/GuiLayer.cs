using System.Collections.Generic;
using UnityEngine;
using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.Runtime.Layers
{
    internal class GuiLayer : IGuiLayer
    {
        public int Index
        {
            get;
        }

        public Transform Root
        {
            get;
        }
    
        private readonly HashSet<IGuiWindow> _windows = new HashSet<IGuiWindow>();

        public GuiLayer(int index, GuiManagerConfig config, Transform guiRoot)
        {
            Index = index;

            var rootGameObject = Object.Instantiate(config.DefaultLayerPrefab, guiRoot);
            rootGameObject.name = $"Layer:{Index}";
            Root = rootGameObject.transform;
        }
    
        public GuiLayer(int index, Transform root)
        {
            Index = index;
            Root = root;
        }

        public void Add(IGuiWindow window)
        {
            _windows.Add(window);
        }

        public void Remove(IGuiWindow window)
        {
            _windows.Remove(window);
        }
    }
}