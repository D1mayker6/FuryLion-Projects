// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;
using Entities;

namespace UI
{
    public class BasePopup : MonoBehaviour
    {
        protected Action OnOkClicked;

        protected Operation Operation;
        
        public virtual void OnOpen(object data)
        {
            if (data is DataMember dataMember)
            {
                OnOkClicked = dataMember.OkButtonAction;
                Operation = dataMember.Operation;
            }
        }
        
        protected virtual void OkClick()
        {
            if (Operation != Operation.Delete)
                OnOkClicked?.Invoke();
            PopupManager.Instance.Close();
        }
        
        public virtual void OnClose(object data)
        {
            OnOkClicked = null;
        }
    }
}
