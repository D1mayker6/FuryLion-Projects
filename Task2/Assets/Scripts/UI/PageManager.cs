// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System.Collections.Generic;
using UnityEngine;
using UI.Pages;

namespace UI
{
    public class PageManager : BaseManager
    {
        [SerializeField] private List<BaseWindow> _pagePrefabs;
        private Stack<BaseWindow> _pageStack = new  Stack<BaseWindow>();

        public static PageManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = GetComponent<PageManager>();
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            Open<MainWindow>();
        }

        public override void Close(object data = null)
        {
            if (_pageStack.Count <= 0)
                return;
            
            var page = _pageStack.Pop();
            page.OnClose(data);
            Destroy(page.gameObject);
            if (_pageStack.Count < 0)
                return;
            
            var previousPage = _pageStack.Peek();
            previousPage.gameObject.SetActive(true);
            previousPage.OnOpen(data); 
        }

        public override void Open<T>(object data = null)
        {
            if (_pageStack.Count > 0)
            {
                var previousPage = _pageStack.Peek();
                previousPage.gameObject.SetActive(false);
                previousPage.OnClose(data);
            }

            foreach (var page in _pagePrefabs)
            {
                if (page.GetType() == typeof(T))
                {
                    var canvasObject = Instantiate(page);
                    canvasObject.OnOpen(data);
                    _pageStack.Push(canvasObject);
                }
            }
        }
    } 
}
