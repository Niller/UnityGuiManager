using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityGuiManager.Runtime.Windows;
using Object = UnityEngine.Object;

namespace UnityGuiManager.Runtime.Contexts
{
    internal class GuiContext : IGuiContext
    {
        public int Id
        {
            get;
        }

        private readonly List<IGuiWindow> _stack = new List<IGuiWindow>();
        private readonly GuiManager _guiManager;

        public GuiContext(int id, GuiManager guiManager)
        {
            Id = id;
            _guiManager = guiManager;
        }
        
        public void CloseAll()
        {
            foreach (var window in _stack.ToList())
            {
                window.Internal.Close();
            }
        }

        public void CloseLast()
        {
            _stack.Last().Internal.Close();
            _stack.RemoveAt(_stack.Count - 1);
        }

        public void Close(BaseWindow window)
        {
            var index = _stack.IndexOf(window);
            _stack[index].Internal.Close();
            _stack.RemoveAt(index);
        }

        public T Open<T>(T window = null) where T : class, IGuiWindow
        {
            if (typeof(T).IsAssignableFrom(typeof(MonoBehaviour)))
            {
                throw new ArgumentException($"Cannot open MonoBehaviour window without an instance as an argument");
            }
            
            window ??= (T)Activator.CreateInstance(typeof(T));

            window.Internal.Inject(_guiManager);
            
            _stack.Add(window);

            return window;
        }

        public IGuiWindow Open<T>(GameObject gameObject) where T : MonoBehaviour
        {
            var layer = _guiManager.GetLayer(0);
            var view = Object.Instantiate(gameObject, layer.Root);
            var monoBehaviour = view.GetComponent<T>();

            var window = new GuiMonoBehaviourWrapper(monoBehaviour);
            
            window.Open(monoBehaviour.gameObject, layer);

            if (monoBehaviour is IGuiWindowChild child)
            {
                child.Link(window);
            }
            
            window.Internal.Inject(_guiManager);
            
            _stack.Add(window);
            
            return window;
        }

        public IGuiWindow Open<T>(object key, IViewMapper viewMapper = null) where T : MonoBehaviour
        {
            viewMapper ??= _guiManager.ViewMapper;

            if (viewMapper == null)
            {
                throw new ArgumentException($"Cannot resolve {nameof(IViewMapper)}");
            }

            var gameObject = viewMapper.Get(key);
            return Open<T>(gameObject);
        }

        public IGuiWindow GetLast()
        {
            return _stack.Count == 0 ? null : _stack.Last();
        }
    }
}