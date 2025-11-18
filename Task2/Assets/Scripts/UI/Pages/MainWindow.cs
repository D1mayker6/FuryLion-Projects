// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;
using Entities;
using UI.Popups;

namespace UI.Pages
{
    public class MainWindow : BaseWindow
    {
        [SerializeField] private Button _addHumanButton;
        [SerializeField] private Button _editHumanButton;
        [SerializeField] private Button _deleteHumanButton;
        [SerializeField] private Button _printHumanButton;
        [SerializeField] private Button _exitButton;

        public override void OnOpen(object data)
        {
            _addHumanButton.onClick.AddListener(AddButton);
            _editHumanButton.onClick.AddListener(EditButton);
            _deleteHumanButton.onClick.AddListener(DeleteButton);
            _printHumanButton.onClick.AddListener(PrintButton);
            _exitButton.onClick.AddListener(ExitButton);
        }

        public override void OnClose(object data)
        {
            _addHumanButton.onClick.RemoveAllListeners();
            _editHumanButton.onClick.RemoveAllListeners();
            _deleteHumanButton.onClick.RemoveAllListeners();
            _printHumanButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }

        public void AddButton()
        {
            PopupManager.Instance.Open<HumanTypePopup>();
        }

        public void EditButton()
        {
            PopupManager.Instance.Open<HumanNumberPopup>(new DataMember(Operation.Edit));
        }

        public void DeleteButton()
        {
            PopupManager.Instance.Open<HumanNumberPopup>(new DataMember(Operation.Delete));
        }

        public void PrintButton()
        {
            PageManager.Instance.Open<PrintWindow>();
        }
        public void ExitButton()
        {
            Application.Quit();
        }
    }
}
