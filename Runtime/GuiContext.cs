using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityGuiManager.Runtime
{
    internal class GuiContext : IGuiContext
    {
        public int Id
        {
            get;
        }

        private readonly List<BaseWindow> _stack = new List<BaseWindow>();
        private readonly GuiManager _guiManager;

        public GuiContext(int id, GuiManager guiManager)
        {
            Id = id;
            _guiManager = guiManager;
        }

        public void Add(BaseWindow window)
        {
            _stack.Add(window);
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