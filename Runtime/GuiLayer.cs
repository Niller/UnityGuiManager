using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityGuiManager.Runtime
{
    internal class GuiLayer
    {
        public int Index
        {
            get;
        }

        public Transform Root
        {
            get;
        }
    
        private readonly List<BaseWindow> _stack = new List<BaseWindow>();
        private readonly GuiManager _guiManager;

        public GuiLayer(int index, GuiManager guiManager)
        {
            Index = index;
            _guiManager = guiManager;

            var rootGameObject = Object.Instantiate(_guiManager.Config.DefaultLayerPrefab, _guiManager.Root);
            rootGameObject.name = $"Layer:{Index}";
            Root = rootGameObject.transform;
        }
    
        public GuiLayer(int index, GuiManager guiManager, Transform root)
        {
            Index = index;
            _guiManager = guiManager;

            Root = root;
        }

        public void Add(BaseWindow window)
        {
            _stack.Add(window);
        }

        public void Insert(int position, BaseWindow window)
        {
            _stack.Insert(position, window);
        }

        public void Remove(BaseWindow window)
        {
            _stack.Remove(window);
        }

        public void RemoveLast()
        {
            _stack.RemoveAt(_stack.Count - 1);
        }

        public void CloseAll()
        {
            foreach (var window in _stack.ToList())
            {
                window.Close();
            }
        }
    }
}