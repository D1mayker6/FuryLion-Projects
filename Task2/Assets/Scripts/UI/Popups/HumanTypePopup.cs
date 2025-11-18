// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;
using Entities;
using UI.Pages.AddEdit;

namespace UI.Popups
{
    public class HumanTypePopup : BasePopup
    {
        [SerializeField] private Button _studentButton;
        [SerializeField] private Button _employeeButton;
        [SerializeField] private Button _driverButton;
        
        public override void OnOpen(object data)
        {
            base.OnOpen(data);
            _studentButton.onClick.AddListener(StudentButton);
            _employeeButton.onClick.AddListener(EmployeeButton);
            _driverButton.onClick.AddListener(DriverButton);
            _studentButton.onClick.AddListener(OkClick);
            _employeeButton.onClick.AddListener(OkClick);
            _driverButton.onClick.AddListener(OkClick);
        }

        public override void OnClose(object data)
        {
            _studentButton.onClick.RemoveAllListeners();
            _employeeButton.onClick.RemoveAllListeners();
            _driverButton.onClick.RemoveAllListeners();
        }

        private void StudentButton()
        {
            PageManager.Instance.Open<AddEditStudentWindow>(new DataMember(Operation.Add, HumanType.Student));
        }

        private void EmployeeButton()
        {
            PageManager.Instance.Open<AddEditEmployeeWindow>(new DataMember(Operation.Add, HumanType.Employee));
        }

        private void DriverButton()
        {
            PageManager.Instance.Open<AddEditDriverWindow>(new DataMember(Operation.Add, HumanType.Driver));
        }
    }
}