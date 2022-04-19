using System;
using UnityEngine;
using UnityGuiManager.Runtime.Components;
using UnityGuiManager.Runtime.Layers;

namespace UnityGuiManager.Runtime.Windows
{
    public abstract class BaseWindow
    {
        private GuiManager _guiManager;

        private RelativeCanvasSortingOrder _sortingOrder;
        private GameObject _gameObject;
        private WindowStatus _status;

        internal GuiLayer Layer { get; private set; }

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

        internal void Inject(GuiManager guiManager)
        {
            _guiManager = guiManager;
        }
    
        internal void Open(GuiLayer layer)
        {
            Layer = layer;
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
        }
    }
}