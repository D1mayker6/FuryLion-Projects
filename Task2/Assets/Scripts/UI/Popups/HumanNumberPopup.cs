// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;
using Entities;
using UI.Pages.AddEdit;

namespace UI.Popups
{
    public class HumanNumberPopup : BasePopup
    {
        [SerializeField] private Button _acceptButton;
        [SerializeField] private InputField _numberInputField;

        protected void Awake()
        {
            _acceptButton.onClick.AddListener(OkClick);
        }

        public override void OnOpen(object data)
        {
            base.OnOpen(data);
            if(data is DataMember dataMember)
                Operation = dataMember.Operation;
        }

        public override void OnClose(object data)
        {
            _acceptButton.onClick.RemoveAllListeners();
        }

        private void AcceptButton()
        {
            int.TryParse(_numberInputField.text, out var numberHuman);
            if (numberHuman > 0 && numberHuman <= HumansList.Humans.Count)
            {
                switch (Operation)
                {
                    case Operation.Delete:
                        DeleteOperation(numberHuman);
                        break;
                    case Operation.Edit:
                        EditOperation(numberHuman);
                        break;
                }
            }
            else
            {
                Debug.Log("Такого человека нет!");
                PopupManager.Instance.Close();
            }
        }

        private void DeleteOperation(int numberHuman)
        {
            var human = HumansList.Humans[numberHuman - 1];
            var data = new DataMember(human.Surname, Operation.Edit, null);
            HumansList.RemoveHuman(human);
            PopupManager.Instance.Close();
            Debug.Log("Удалено");
        }

        private void EditOperation(int numberHuman)
        {
            numberHuman = numberHuman - 1;
            var human = HumansList.Humans[numberHuman];
            var data = new DataMember(Operation.Edit, numberHuman);
            switch (GetHumanType(human))
            {
                case HumanType.Student:
                    PageManager.Instance.Open<AddEditStudentWindow>(data);
                    break;
                case HumanType.Employee:
                    PageManager.Instance.Open<AddEditEmployeeWindow>(data);
                    break;
                case HumanType.Driver:
                    PageManager.Instance.Open<AddEditDriverWindow>(data);
                    break;
            }
        }

        private HumanType GetHumanType(Human human)
        {
            switch (human.GetType().Name)
            {
                case "Student":
                    return HumanType.Student;
                    break;
                case "Employee":
                    return HumanType.Employee;
                    break;
                case "Driver":
                    return HumanType.Driver;
                    break;
                default:
                    return 0;
                    break;
            }
        }
        
        protected override void OkClick()
        {
            AcceptButton();
            base.OkClick();
        }
    }
}