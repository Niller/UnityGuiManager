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
        
        T Open<T>(T window = null) where T : class, IGuiWindow;
        IGuiOperation Open<T>(GameObject window) where T : MonoBehaviour;
        IGuiOperation Open<T>(object key, IViewMapper viewMapper = null) where T : MonoBehaviour;
        
        IGuiWindow GetLast();
    }
}