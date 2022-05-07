using System;

namespace UnityGuiManager.Runtime.Operations
{
    public interface IGuiOperation
    {
        event Action<GuiOperationStatus> StatusChanged;
        TResult GetResult<TResult>();
        GuiOperationStatus Status { get; }
    }
}