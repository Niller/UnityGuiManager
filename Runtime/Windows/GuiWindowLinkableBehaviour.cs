using UnityEngine;

namespace UnityGuiManager.Runtime.Windows
{
    public abstract class GuiWindowLinkableBehaviour : MonoBehaviour, IGuiWindowChild
    {
        protected IGuiWindow window;
        
        public void Link(IGuiWindow w)
        {
            window = w;
        }
    }
}