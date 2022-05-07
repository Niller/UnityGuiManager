using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.Runtime.Layers
{
    internal class LayersManager : ILayerController
    {
        private readonly List<IGuiLayer> _layers = new List<IGuiLayer>();
        private readonly Dictionary<IGuiWindow, IGuiLayer> _windowsMapping = new Dictionary<IGuiWindow, IGuiLayer>();

        public void AddWindow(IGuiWindow window, int layerIndex)
        {
            var layer = _layers[layerIndex];
            layer.Add(window);
            _windowsMapping[window] = layer;
        }
        
        public void AddWindow(IGuiWindow window, IGuiLayer layer)
        {
            layer.Add(window);
            _windowsMapping[window] = layer;
        }

        public void RemoveWindow(IGuiWindow window)
        {
            _windowsMapping[window].Remove(window);
        }

        public void AddLayer(GuiManagerConfig config, Transform root)
        {
            _layers.Add(new GuiLayer(_layers.Count, config, root));
        }

        public void AddLayer()
        {
            throw new NotSupportedException();
        }

        public void AddLayer(Transform layer)
        {
            _layers.Add(new GuiLayer(_layers.Count, layer));
        }

        public IGuiLayer GetLayer(int index)
        {
            return _layers[index];
        }
    }
}