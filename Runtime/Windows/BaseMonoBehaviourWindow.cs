using System;
using UnityEngine;

namespace UnityGuiManager.Runtime.Windows
{
    public abstract class BaseMonoBehaviourWindow : MonoBehaviour, IGuiWindow
    {
        public BaseWindow Internal
        {
            get;
            private set;
        }

        public event Action<WindowStatus> StatusChanged
        {
            add => Internal.StatusChanged += value;
            remove => Internal.StatusChanged -= value;
        }
        
        public WindowStatus Status => Internal.Status;
    }
}