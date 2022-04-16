using System.Collections.Generic;
using System.Linq;

internal class GuiLayer
{
    public int Index
    {
        get;
    }
    
    private readonly List<BaseWindow> _stack = new List<BaseWindow>();
    private readonly GuiManager _guiManager;

    public GuiLayer(int index, GuiManager guiManager)
    {
        Index = index;
        _guiManager = guiManager;
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