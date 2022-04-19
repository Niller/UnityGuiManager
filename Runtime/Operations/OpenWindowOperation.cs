using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.Runtime.Operations
{
    public class OpenWindowOperation : GuiOperation
    {
        private readonly BaseWindow _window;

        public OpenWindowOperation(BaseWindow window)
        {
            _window = window;
        }

        public override void Run()
        {
            base.Run();
            
            _window.StatusChanged += WindowStatusChanged;
        }

        private void WindowStatusChanged(WindowStatus status)
        {
            if (status > WindowStatus.Opening)
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