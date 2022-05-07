using System;

namespace UnityGuiManager.Runtime.Operations
{
    public abstract class GuiOperation : IGuiOperation, IDisposable
    {
        private GuiOperationStatus _status;
        protected GuiManager guiManager;
        
        protected object Result { get; set; }
        
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

        public virtual void Run(GuiManager guiManagerArg)
        {
            guiManager = guiManagerArg;
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

        public TResult GetResult<TResult>()
        {
            return (TResult) Result;
        }
    }
}