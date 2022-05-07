using System;
using UnityEngine;
using UnityGuiManager.Runtime;
using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.TestsScripts
{
    public class NotificationWindow2 : GuiWindowLinkableBehaviour
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
        
        private void OnDestroy()
        {
            window.Status = WindowStatus.Closed;
        }

        public void OnOpenButtonClick()
        { 
            _manager.CurrentContext.Open<NotificationWindow1>("NotificationWindow1");
        }

        public void OnCloseButtonClick()
        {
            _manager.CloseLast();
        }
    }
}