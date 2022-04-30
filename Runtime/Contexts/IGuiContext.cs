using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.Runtime.Contexts
{
    public interface IGuiContext
    {
        void CloseAll();
        void CloseLast();
        void Close(BaseWindow window);
        T Open<T>(T window = null) where T : class, IGuiWindow;
        IGuiWindow GetLast();
    }
}