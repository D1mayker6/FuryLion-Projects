// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;
using Entities;
using UI.Popups;

namespace UI.Pages.AddEdit
{
    public class AddEditEmployeeWindow : AddEditBaseWindow
    {
        [SerializeField] private InputField _organisationField;
        [SerializeField] private InputField _salaryField;
        [SerializeField] private InputField _experienceField;
        
        protected override void SetupInputField()
        {
            base.SetupInputField();
            var student = (Employee)HumanToEdit;
            _organisationField.text = student.Organisation;
            _salaryField.text = student.Salary.ToString();
            _experienceField.text = student.Experience.ToString();
        }

        protected override void AddHuman()
        {
            try
            {
                Human human = null;
                base.AddHuman();
                var organisation = _organisationField.text;
                var salary = int.Parse(_salaryField.text);
                var experience = int.Parse(_experienceField.text);
                human = new Employee(Surname, Name, Patronomyc, Birthday, organisation, salary, experience);
                HumansList.AddHuman(human);
                PopupManager.Instance.Open<InfoPopup>(new DataMember(human.Surname,  Operation.Add, OkButton));
            }   
            catch
            {
                PopupManager.Instance.Open<InfoPopup>(new DataMember(Operation.Error, OkButton));   
            }
        }

        protected override void EditHuman()
        {
            try
            {
                base.EditHuman();
                var employee = (Employee)HumanToEdit;
                employee.Organisation = _organisationField.text;
                employee.Salary = int.Parse(_salaryField.text);
                employee.Experience = int.Parse(_experienceField.text);
                PopupManager.Instance.Open<InfoPopup>(new DataMember(employee.Surname,  Operation.Edit, OkButton));
            }   
            catch
            {
                PopupManager.Instance.Open<InfoPopup>(new DataMember(Operation.Error, OkButton));   
            }
        }
    }
}
