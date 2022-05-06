using UnityEngine;

namespace UnityGuiManager.Runtime.Windows
{
    public class GuiMonoBehaviourWrapper : BaseWindow
    {
        private readonly MonoBehaviour _behaviour;
        
        protected override GameObject Prefab => _behaviour.gameObject;

        public GuiMonoBehaviourWrapper(MonoBehaviour behaviour)
        {
            _behaviour = behaviour;
        }

        protected override void NotifyStatusChanged(WindowStatus status)
        {
            base.NotifyStatusChanged(status);
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (_behaviour is IStatusChangedListener statusChangedListener)
            {
                statusChangedListener.OnStatusChanged(status);
            }
        }
    }
}