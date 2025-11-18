// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UnityEngine;

namespace UI
{
    interface IViewManager
    {
        void Open<T>(object data = null) where T : Component;

        void Close(object data = null);
    }
}
