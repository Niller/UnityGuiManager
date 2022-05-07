using System.Collections.Generic;
using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.Runtime.Contexts
{
    internal class GuiContextsManager : ContainersManager<IGuiContext, IGuiWindow>, IGuiContextController
    {
        private readonly GuiManager _guiManager;

        public IGuiContext CurrentContext { get; private set; }

        public GuiContextsManager(GuiManager guiManager)
        {
            _guiManager = guiManager;
        }
        
        public void AddWindow(IGuiWindow window, IGuiContext context)
        {
            AddItem(window, context);
            context.Register(window);
        }

        public void RemoveWindow(IGuiWindow item)
        {
            itemsMapping[item].Unregister(item);
            RemoveItem(item);
        }

        public IGuiContext AddContext()
        {
            var context = new GuiContext(containers.Count, _guiManager);
            containers.Add(context);

            CurrentContext ??= context;
            
            return context;
        }
        
        public IGuiContext GetContext(int index)
        {
            return GetContainer(index);
        }

        public void SwitchCurrentContext(int index)
        {
            CurrentContext = containers[index];
        }
    }
}