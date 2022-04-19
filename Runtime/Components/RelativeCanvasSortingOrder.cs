using UnityEngine;

namespace UnityGuiManager.Runtime.Components
{
    [RequireComponent(typeof(Canvas))]
    public class RelativeCanvasSortingOrder : MonoBehaviour
    {
        private Canvas _canvas;
        private Canvas _parentCanvas;

        [SerializeField]
        private int _sortingOrder;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _canvas.overrideSorting = true;
            _parentCanvas = GetComponentInParent<Canvas>();
            UpdateSortOrder(_sortingOrder);
        }

        public void UpdateSortOrder(int sortingOrder)
        {
            _sortingOrder = sortingOrder;
            _canvas.sortingOrder = _parentCanvas.sortingOrder + _sortingOrder;
        }

        [ContextMenu("Force Update")]
        private void ForceUpdate()
        {
            UpdateSortOrder(_sortingOrder);
        }
    }
}