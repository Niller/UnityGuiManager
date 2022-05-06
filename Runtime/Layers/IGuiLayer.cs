﻿using UnityEngine;
using UnityGuiManager.Runtime.Windows;

namespace UnityGuiManager.Runtime.Layers
{
    public interface IGuiLayer
    {
        Transform Root { get; }
        void Remove(IGuiWindow window);
    }
}