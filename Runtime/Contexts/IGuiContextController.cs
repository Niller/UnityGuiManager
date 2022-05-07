namespace UnityGuiManager.Runtime.Contexts
{
    public interface IGuiContextController
    {
        public IGuiContext CurrentContext { get; }
        IGuiContext AddContext();
        IGuiContext GetContext(int index);
        void SwitchCurrentContext(int index);

    }
}