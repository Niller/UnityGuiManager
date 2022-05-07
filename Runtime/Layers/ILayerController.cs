using UnityEngine;

namespace UnityGuiManager.Runtime.Layers
{
    public interface ILayerController
    {
        IGuiLayer GetLayer(int index);
        void AddLayer();
        void AddLayer(Transform layer);
    }
}