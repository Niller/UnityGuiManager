using UnityEngine;
using UnityGuiManager.Runtime.Operations;
using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.Runtime.Contexts
{
    public interface IGuiContext
    {
        void CloseAll();
        void CloseLast();
        void Close(IGuiWindow window);
        
        IGuiOperation Open<T>(GameObject window, int layer) where T : MonoBehaviour;
        IGuiOperation Open<T>(object key, int? layer = null, IViewMapper viewMapper = null) where T : MonoBehaviour;
        
        IGuiWindow GetLast();
        
        void Register(IGuiWindow window);
        void Unregister(IGuiWindow window);
    }
}