using System;
using UnityEngine;

namespace UnityGuiManager.Runtime
{
    [CreateAssetMenu]
    public class GuiManagerConfig : ScriptableObject
    {
        [field: SerializeField]
        public GameObject DefaultLayerPrefab { get; set; }
    }
}