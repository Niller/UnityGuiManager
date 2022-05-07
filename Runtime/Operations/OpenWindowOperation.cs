using UnityEngine;
using UnityGuiManager.Runtime.Contexts;
using UnityGuiManager.Runtime.Layers;
using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.Runtime.Operations
{
    internal class OpenWindowOperation<T> : GuiOperation where T : MonoBehaviour
    {
        private IGuiWindow _window;
        private readonly GameObject _gameObject;
        private readonly IGuiLayer _layer;
        private readonly GuiContext _context;
        
        public OpenWindowOperation(GameObject gameObject, IGuiLayer layer, GuiContext context)
        {
            _gameObject = gameObject;
            _layer = layer;
            _context = context;

        }

        public override void Run(GuiManager guiManagerArg)
        {
            base.Run(guiManagerArg);
            
            var isOnScene = _gameObject.scene.name != null;
            
            var view = Object.Instantiate(_gameObject, _layer.Root);
            var monoBehaviour = view.GetComponent<T>();

            var window = new GuiMonoBehaviourWrapper(monoBehaviour);
            
            window.Setup(monoBehaviour.gameObject, guiManager);

            if (monoBehaviour is IGuiWindowChild child)
            {
                child.Link(window);
            }
            
            _context.Register(window);
            guiManager.Register(window, _layer);

            _window = window;
            Result = window;
            
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