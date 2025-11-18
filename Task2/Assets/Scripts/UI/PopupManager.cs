// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class PopupManager : BaseManager
    {
        [SerializeField] private List<BasePopup> _popupPrefabs;
        private Stack<BasePopup> _popupStack = new  Stack<BasePopup>();

        public static PopupManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = GetComponent<PopupManager>();
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }

        public override void Close(object data = null)
        {
            if (_popupStack.Count <= 0)
                return;
            
            var popup = _popupStack.Pop();
            popup.OnClose(data);
            Destroy(popup.gameObject);
            if (_popupStack.Count <= 0)
                return;
            var previousPopup = _popupStack.Peek();
            previousPopup.OnOpen(data); 
            
        }

        public override void Open<T>(object data = null)
        {
            if (_popupStack.Count > 0)
            {
                var previousPopup = _popupStack.Peek();
                previousPopup.gameObject.SetActive(false);
                previousPopup.OnClose(data);
            }
            
            foreach (var popup in _popupPrefabs)
            {
                if (popup.GetType() == typeof(T))
                {
                    var canvasObject = Instantiate(popup);
                    canvasObject.OnOpen(data);
                    _popupStack.Push(canvasObject);
                }
            }
        }
    }
}
