// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;
using Entities;
using UI.Popups;

namespace UI.Pages.AddEdit
{
    public class AddEditStudentWindow : AddEditBaseWindow
    {
        [SerializeField] private InputField _facultyField;
        [SerializeField] private InputField _courseField;
        [SerializeField] private InputField _groupField;
        
        protected override void SetupInputField()
        {
            base.SetupInputField();
            var student = (Student)HumanToEdit;
            _facultyField.text = student.Faculty;
            _courseField.text = student.Course.ToString();
            _groupField.text = student.Group.ToString();
        }

        protected override void AddHuman()
        {
            try
            {
                Human human = null;
                base.AddHuman();
                var faculty = _facultyField.text;
                var course = int.Parse(_courseField.text);
                var group = int.Parse(_groupField.text);
                human = new Student(Surname, Name, Patronomyc, Birthday, faculty, course, group);
                HumansList.AddHuman(human);
                PopupManager.Instance.Open<InfoPopup>(new DataMember(human.Surname, Operation.Add, OkButton));
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
                var student = (Student)HumanToEdit;
                student.Faculty = _facultyField.text;
                int.TryParse(_courseField.text, out var course);
                student.Course = course;
                int.TryParse(_groupField.text, out var group);
                student.Group = group;
                PopupManager.Instance.Open<InfoPopup>(new DataMember(student.Surname,  Operation.Edit, OkButton));
            }
            catch
            {
                PopupManager.Instance.Open<InfoPopup>(new DataMember(Operation.Error, OkButton));   
            }
        }
    }
}
