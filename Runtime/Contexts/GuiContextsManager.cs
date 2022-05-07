using System.Collections.Generic;

namespace UnityGuiManager.Runtime.Contexts
{
    internal class GuiContextsManager : IGuiContextController
    {
        private readonly List<GuiContext> _contexts = new List<GuiContext>();
        private readonly GuiManager _guiManager;

        public IGuiContext CurrentContext { get; private set; }

        public GuiContextsManager(GuiManager guiManager)
        {
            _guiManager = guiManager;
        }

        public IGuiContext AddContext()
        {
            var context = new GuiContext(_contexts.Count, _guiManager);
            _contexts.Add(context);

            CurrentContext ??= context;
            
            return context;
        }
        
        public IGuiContext GetContext(int index)
        {
            return _contexts[index];
        }

        public void SwitchCurrentContext(int index)
        {
            CurrentContext = _contexts[index];
        }
    }
}