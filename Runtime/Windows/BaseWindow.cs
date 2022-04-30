using System;
using UnityEngine;
using UnityGuiManager.Runtime.Components;
using UnityGuiManager.Runtime.Layers;
using Object = UnityEngine.Object;

namespace UnityGuiManager.Runtime.Windows
{
    public abstract class BaseWindow: IGuiWindow 
    {
        private GuiManager _guiManager;

        private RelativeCanvasSortingOrder _sortingOrder;
        private GameObject _gameObject;
        private WindowStatus _status;
        private Action _closeStrategy;

        protected abstract GameObject Prefab { get; }
        
        internal GuiLayer Layer { get; private set; }

        public BaseWindow Internal => this;
        public event Action<WindowStatus> StatusChanged;
        
        public WindowStatus Status
        {
            get => _status;
            protected set
            {
                if (_status == value)
                {
                    return;
                }

                _status = value;
                StatusChanged?.Invoke(_status);
            }
        }

        public void SetCloseStrategy(Action action)
        {
            if (_closeStrategy == null)
            {
                DefaultCloseStrategy();
                return;
            }
            
            _closeStrategy = action;
        }

        internal void Inject(GuiManager guiManager)
        {
            _guiManager = guiManager;
        }
    
        internal void Open(GuiLayer layer)
        {
            Layer = layer;

            _gameObject = Object.Instantiate(Prefab, layer.Root);
            SetupGameObject(_gameObject);
        }

        internal void SetupGameObject(GameObject gameObject)
        {
            _gameObject = gameObject;
            
            _sortingOrder = _gameObject.GetComponent<RelativeCanvasSortingOrder>();
            if (_sortingOrder == null)
            {
                _sortingOrder = _gameObject.AddComponent<RelativeCanvasSortingOrder>();
            }
        }

        internal void ChangeLayer(GuiLayer layer)
        {
            Layer = layer;
        }

        internal void Close()
        {
            _guiManager.Close(this);
            
            if (_closeStrategy == null)
            {
                DefaultCloseStrategy();
                return;
            }
            
            _closeStrategy.Invoke();
        }

        private void DefaultCloseStrategy()
        {
            Object.Destroy(_gameObject);
        }
    }
}