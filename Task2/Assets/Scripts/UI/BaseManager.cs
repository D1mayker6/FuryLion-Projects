// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UnityEngine;

namespace UI
{
    public abstract class BaseManager: MonoBehaviour, IViewManager
    {
        public abstract void Open<T>(object data = null) where T : Component;
        
        public abstract void Close(object data = null);
    }
}