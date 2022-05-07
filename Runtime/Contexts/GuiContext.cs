using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityGuiManager.Runtime.Operations;
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
                Close(window);
            }
        }

        public void CloseLast()
        {
            _stack.Last().Internal.Close();
            _stack.RemoveAt(_stack.Count - 1);
        }

        public void Close(IGuiWindow window)
        {
            var index = _stack.IndexOf(window);

            var operation = _guiManager.OperationsDispatcher.Dispatch(new CloseWindowOperation(_stack[index]));

            operation.StatusChanged += (status) =>
            {
                if (status == GuiOperationStatus.Finished)
                {
                    _stack.RemoveAt(index);
                }
            };
        }

        public T Open<T>(T window = null) where T : class, IGuiWindow
        {
            if (typeof(T).IsAssignableFrom(typeof(MonoBehaviour)))
            {
                throw new ArgumentException($"Cannot open MonoBehaviour window without an instance as an argument");
            }
            
            window ??= (T)Activator.CreateInstance(typeof(T));

            _stack.Add(window);

            return window;
        }

        public IGuiOperation Open<T>(GameObject gameObject) where T : MonoBehaviour
        { 
            var operation = _guiManager.OperationsDispatcher.Dispatch(new OpenWindowOperation<T>(gameObject, _guiManager.GetLayer(0), this));
            
            operation.StatusChanged += (status) =>
            {
                if (status >= GuiOperationStatus.Processing)
                {
                    _stack.Add(operation.GetResult<IGuiWindow>());
                }
            };
            
            return operation;
        }

        public IGuiOperation Open<T>(object key, IViewMapper viewMapper = null) where T : MonoBehaviour
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
            return _stack.LastOrDefault();
        }
    }
}