using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityGuiManager.Runtime.Windows;

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
            if (window == null)
            {
                if (typeof(T).IsAssignableFrom(typeof(MonoBehaviour)))
                {
                    throw new ArgumentException($"Cannot open MonoBehaviour window without an instance as an argument");
                }
                
                window = (T) Activator.CreateInstance(typeof(T));
            }
            
            window.Internal.Inject(_guiManager);
            
            _stack.Add(window);

            return window;
        }

        public IGuiWindow GetLast()
        {
            return _stack.Count == 0 ? null : _stack.Last();
        }
    }
}