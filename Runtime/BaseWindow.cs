public abstract class BaseWindow
{
    private GuiManager _guiManager;

    internal GuiLayer Layer { get; private set; }

    internal void Inject(GuiManager guiManager)
    {
        _guiManager = guiManager;
    }
    
    internal void Open(GuiLayer layer)
    {
        Layer = layer;
    }

    internal void ChangeLayer(GuiLayer layer)
    {
        Layer = layer;
    }

    internal void Close()
    {
        _guiManager.Close(this);
    }
}