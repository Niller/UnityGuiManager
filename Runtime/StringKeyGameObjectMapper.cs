using System.Collections.Generic;
using UnityEngine;

namespace UnityGuiManager.Runtime
{
    public class StringKeyGameObjectMapper : IViewMapper
    {
        private readonly Dictionary<string, ViewMapperItem> _dictionary = new Dictionary<string, ViewMapperItem>();

        public ViewMapperItem Get(object key)
        {
            return _dictionary[(string) key];
        }

        public void Set(string key, ViewMapperItem item)
        {
            _dictionary[key] = item;
        }
        
        public void Set(string key, GameObject gameObject, int layer)
        {
            _dictionary[key] = new ViewMapperItem(gameObject, layer);
        }
    }
}