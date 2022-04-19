using System.Collections.Generic;

namespace UnityGuiManager.Runtime.Operations
{
    internal class GuiOperationsDispatcher
    {
        private readonly List<GuiOperation> _operations = new List<GuiOperation>();

        private GuiOperation _current;

        public void Run()
        {
            if (_operations.Count <= 0)
            {
                return;
            }

            _current = _operations[0];
            _operations.RemoveAt(0);
            
            _current.StatusChanged += OnOperationStatusChanged;
            
            _current.Run();
        }

        private void OnOperationStatusChanged(GuiOperationStatus status)
        {
            if (status == GuiOperationStatus.Finished)
            {
                Run();
            }
        }

        public void ClearAll()
        {
            _operations.Clear();
            _current.Stop();
            _current = null;
        }

        public void StopCurrent()
        {
            _current.Stop();
        }
    }
}