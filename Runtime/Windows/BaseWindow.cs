using System;
using UnityEngine;
using UnityGuiManager.Runtime.Components;
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

        public BaseWindow Internal => this;
        public event Action<WindowStatus> StatusChanged;
        
        public WindowStatus Status
        {
            get => _status;
            set
            {
                if (_status == value)
                {
                    return;
                }

                _status = value;
                NotifyStatusChanged(_status);
            }
        }

        protected virtual void NotifyStatusChanged(WindowStatus status)
        {
            StatusChanged?.Invoke(_status);
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

        internal void Setup(GameObject gameObject, GuiManager guiManager)
        {
            _gameObject = gameObject;
            _guiManager = guiManager;
            
            _sortingOrder = _gameObject.GetComponent<RelativeCanvasSortingOrder>();
            if (_sortingOrder == null)
            {
                _sortingOrder = _gameObject.AddComponent<RelativeCanvasSortingOrder>();
            }
        }

        internal void Close()
        {
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