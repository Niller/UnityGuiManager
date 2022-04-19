using UnityEngine;
using UnityGuiManager.Runtime.Components;

namespace UnityGuiManager.Runtime
{
    public abstract class BaseWindow
    {
        private GuiManager _guiManager;

        private RelativeCanvasSortingOrder _sortingOrder;
        private GameObject _gameObject;

        internal GuiLayer Layer { get; private set; }

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