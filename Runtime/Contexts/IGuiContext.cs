using UnityEngine;
using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.Runtime.Contexts
{
    public interface IGuiContext
    {
        void CloseAll();
        void CloseLast();
        void Close(BaseWindow window);
        
        T Open<T>(T window = null) where T : class, IGuiWindow;
        IGuiWindow Open<T>(GameObject window) where T : MonoBehaviour;
        IGuiWindow Open<T>(object key, IViewMapper viewMapper = null) where T : MonoBehaviour;
        
        IGuiWindow GetLast();
    }
}