using UnityEngine;
using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.Runtime.Operations
{
    public class OpenWindowOperation : GuiOperation
    {
        private readonly IGuiWindow _window;

        public OpenWindowOperation(IGuiWindow window)
        {
            _window = window;
        }
        
        public OpenWindowOperation(GameObject window)
        {
            _window = window.scene.name == null 
                ? Object.Instantiate(window).GetComponent<IGuiWindow>() 
                : window.GetComponent<IGuiWindow>();
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