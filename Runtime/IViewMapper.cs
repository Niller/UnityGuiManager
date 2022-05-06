using UnityEngine;

namespace UnityGuiManager.Runtime
{
    public interface IViewMapper
    {
        GameObject Get(object key);
    }
}