using System;

namespace UnityGuiManager.Runtime.Windows
{
    public interface IGuiWindow
    {
        BaseWindow Internal { get; }
        event Action<WindowStatus> StatusChanged;
        WindowStatus Status { get; }
    }
}