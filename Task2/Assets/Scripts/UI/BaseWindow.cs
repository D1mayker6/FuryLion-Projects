// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UnityEngine;

namespace UI
{
    public abstract class BaseWindow:MonoBehaviour
    {
        public abstract void OnOpen(object data);

        public abstract void OnClose(object data);
    }
}
