using System;
using UnityEngine;
using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.Runtime.Layers
{
    internal class LayersManager : ContainersManager<IGuiLayer, IGuiWindow>, ILayerController
    {
        public void AddWindow(IGuiWindow window, int layerIndex)
        {
            var layer = containers[layerIndex];
            AddWindow(window, layer);
        }
        
        public void AddWindow(IGuiWindow window, IGuiLayer layer)
        {
            AddItem(window, layer);
            layer.Add(window);
        }

        public void RemoveWindow(IGuiWindow item)
        {
            itemsMapping[item].Remove(item);
            RemoveItem(item);
        }

        public void AddLayer(GuiManagerConfig config, Transform root)
        {
            containers.Add(new GuiLayer(containers.Count, config, root));
        }

        public void AddLayer()
        {
            throw new NotSupportedException();
        }

        public void AddLayer(Transform layer)
        {
            containers.Add(new GuiLayer(containers.Count, layer));
        }

        public IGuiLayer GetLayer(int index)
        {
            return GetContainer(index);
        }
    }
}