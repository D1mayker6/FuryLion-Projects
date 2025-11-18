// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;
using Entities;
using UI.Popups;

namespace UI.Pages.AddEdit
{
    public class AddEditDriverWindow : AddEditBaseWindow
    {
        [SerializeField] private InputField _organisationField;
        [SerializeField] private InputField _salaryField;
        [SerializeField] private InputField _experienceField;
        [SerializeField] private InputField _markField;
        [SerializeField] private InputField _modelField;
        
        protected override void SetupInputField()
        {
            base.SetupInputField();
            var student = (Driver)HumanToEdit;
            _organisationField.text = student.Organisation;
            _salaryField.text = student.Salary.ToString();
            _experienceField.text = student.Experience.ToString();
            _markField.text = student.Mark;
            _modelField.text = student.Model;
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
                var mark = _markField.text;
                var model = _modelField.text;
                human = new Driver(Surname, Name, Patronomyc, Birthday, organisation, salary, experience, mark, model);
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
                var driver = (Driver)HumanToEdit;
                driver.Organisation = _organisationField.text;
                driver.Salary = int.Parse(_salaryField.text);
                driver.Experience = int.Parse(_experienceField.text);
                driver.Mark = _markField.text;
                driver.Model = _modelField.text;
                PopupManager.Instance.Open<InfoPopup>(new DataMember(driver.Surname,  Operation.Edit, OkButton));
            }   
            catch
            {
                PopupManager.Instance.Open<InfoPopup>(new DataMember(Operation.Error, OkButton));   
            }
        }
    }
}
