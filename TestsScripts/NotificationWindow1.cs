using UnityGuiManager.Runtime;
using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.TestsScripts
{
    public class NotificationWindow1 : GuiWindowLinkableBehaviour
    {
        private GuiManager _manager;
        
        public void Inject(GuiManager manager)
        {
            _manager = manager;
        }

        private void Start()
        {
            window.Status = WindowStatus.Opened;
        }

        public void OnOpenButtonClick()
        { 
            _manager.CurrentContext.Open<NotificationWindow2>("NotificationWindow2");
        }

        public void OnCloseButtonClick()
        {
        
        }
    }
}
