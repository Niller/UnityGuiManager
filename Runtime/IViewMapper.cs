using UnityEngine;

namespace UnityGuiManager.Runtime
{
    public interface IViewMapper
    {
        ViewMapperItem Get(object key);
    }
}