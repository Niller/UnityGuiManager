using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityGuiManager.Runtime
{
    internal abstract class ContainersManager<TContainer, TItem>
    {
        protected readonly List<TContainer> containers = new List<TContainer>();
        protected readonly Dictionary<TItem, TContainer> itemsMapping = new Dictionary<TItem, TContainer>();

        protected void AddItem(TItem item, TContainer container)
        {
            itemsMapping[item] = container;
        }

        protected void RemoveItem(TItem item)
        {
            itemsMapping.Remove(item);
        }
        
        protected TContainer GetContainer(int index)
        {
            return containers[index];
        }
    }
}