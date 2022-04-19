using System;

namespace UnityGuiManager.Runtime.Operations
{
    public abstract class GuiOperation : IDisposable
    {
        private GuiOperationStatus _status;
        
        public GuiOperationStatus Status
        {
            get => _status;
            protected set
            {
                if (_status == value)
                {
                    return;
                }

                _status = value;
                StatusChanged?.Invoke(_status);
            }
        }

        public event Action<GuiOperationStatus> StatusChanged;

        public virtual void Run()
        {
            Status = GuiOperationStatus.Processing;
        }

        public virtual void Stop()
        {
            Status = GuiOperationStatus.Finished;
        }

        public virtual void Finish()
        {
            Status = GuiOperationStatus.Finished;
        }
        
        public virtual void Dispose()
        {
            StatusChanged = null;
        }
    }
}