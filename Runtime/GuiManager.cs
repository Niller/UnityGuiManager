using UnityEngine;
using UnityGuiManager.Runtime.Contexts;
using UnityGuiManager.Runtime.Layers;
using UnityGuiManager.Runtime.Operations;
using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.Runtime
{
    public class GuiManager : ILayerController, IGuiContextController
    {
        private const string DefaultRootName = "GuiManager";
        
        private readonly LayersManager _layersManager = new LayersManager();
        private readonly GuiContextsManager _contextsManager;

        public Transform Root { get; }

        internal GuiManagerConfig Config { get; }
        internal IViewMapper ViewMapper { get; private set; }
        public IGuiContext CurrentContext => _contextsManager.CurrentContext;
        internal GuiOperationsDispatcher OperationsDispatcher { get; }

        private GuiManager()
        {
            _contextsManager = new GuiContextsManager(this);
            OperationsDispatcher = new GuiOperationsDispatcher(this);
        }

        public GuiManager(GuiManagerConfig config) : this()
        {
            Config = config;
            Root = new GameObject(DefaultRootName).transform;
        }

        public GuiManager(GuiManagerConfig config, Transform root) : this()
        {
            Config = config;
            Root = root;

            foreach (Transform layer in Root)
            {
                _layersManager.AddLayer(layer);
            }
        }

        public void SetViewMapper(IViewMapper viewMapper)
        {
            ViewMapper = viewMapper;
        }

        internal void Close(BaseWindow window)
        {
            _layersManager.RemoveWindow(window);
        }

        public void CloseLast()
        {
        }

        public void CloseAll()
        {
        }

        public void Register(IGuiWindow window, IGuiLayer layer, IGuiContext context)
        {
            _layersManager.AddWindow(window, layer);
            _contextsManager.AddWindow(window, context);
        }

        public IGuiLayer GetLayer(int index)
        {
            return _layersManager.GetLayer(index);
        }

        public void AddLayer()
        {
            AddLayer(Config, Root);
        }

        public void AddLayer(Transform layer)
        {
            _layersManager.AddLayer(layer);
        }

        private void AddLayer(GuiManagerConfig config, Transform root)
        {
            _layersManager.AddLayer(config, root);
        }
        
        public IGuiContext AddContext()
        {
            return _contextsManager.AddContext();
        }

        public IGuiContext GetContext(int index)
        {
            return _contextsManager.GetContext(index);
        }

        public void SwitchCurrentContext(int index)
        {
            _contextsManager.SwitchCurrentContext(index);
        }
    }
}