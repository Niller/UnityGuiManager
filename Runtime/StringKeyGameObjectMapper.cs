using System.Collections.Generic;
using UnityEngine;

namespace UnityGuiManager.Runtime
{
    public class StringKeyGameObjectMapper : IViewMapper
    {
        private Dictionary<string, GameObject> _dictionary = new Dictionary<string, GameObject>();

        public GameObject Get(object key)
        {
            return _dictionary[(string) key];
        }

        public void Set(string key, GameObject gameObject)
        {
            _dictionary[key] = gameObject;
        }
    }
}