using UnityEngine;
using UnityGuiManager.Runtime;
using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.TestsScripts
{
    public class NotificationWindow2 : BaseMonoBehaviourWindow
    {
        private GuiManager _manager;
        
        public void Inject(GuiManager manager)
        {
            _manager = manager;
        }
        
        public void OnOpenButtonClick()
        { 
            _manager.CurrentContext.Open<NotificationWindow1>();
        }

        public void OnCloseButtonClick()
        {
            _manager.CloseLast();
        }
    }
}