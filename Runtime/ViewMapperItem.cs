using UnityEngine;

namespace UnityGuiManager.Runtime
{
    public struct ViewMapperItem
    {
        public GameObject gameObject;
        public int layer;

        public ViewMapperItem(GameObject gameObject, int layer)
        {
            this.gameObject = gameObject;
            this.layer = layer;
        }
    }
}