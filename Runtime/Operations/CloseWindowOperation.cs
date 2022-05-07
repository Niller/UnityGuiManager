using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.Runtime.Operations
{
    public class CloseWindowOperation : GuiOperation
    {
        private readonly IGuiWindow _window;

        public CloseWindowOperation(IGuiWindow window)
        {
            _window = window;
        }

        protected override void RunInternal()
        {
            _window.Internal.Close();
            
            _window.StatusChanged += WindowStatusChanged;
        }

        private void WindowStatusChanged(WindowStatus status)
        {
            if (status >= WindowStatus.Closed)
            {
                Finish();
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            _window.StatusChanged -= WindowStatusChanged;
        }
    }
}