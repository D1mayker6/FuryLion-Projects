// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;
using UnityEngine.UI;
using Entities;

namespace UI.Pages.AddEdit
{
    public class AddEditBaseWindow : BaseWindow
    {
        [SerializeField] protected Button _acceptButton;
        
        [SerializeField] protected InputField _surnameField;
        [SerializeField] protected InputField _nameField;
        [SerializeField] protected InputField _patronomycField;
        [SerializeField] protected InputField _birthdayField;
        
        protected Operation Operation;
        protected Human HumanToEdit;
        protected HumanType EditHumanType;

        protected string Surname;
        protected string Name;
        protected string Patronomyc;
        protected DateTime Birthday;

        public override void OnOpen(object data)
        {
            if (data is DataMember dataMember)
            {
                Operation = dataMember.Operation;
                if (Operation == Operation.Edit)
                    HumanToEdit = HumansList.Humans[dataMember.HumanNumber];
            }
            
            _acceptButton.onClick.AddListener(AcceptButton);
        }

        public override void OnClose(object data)
        {
            _acceptButton.onClick.RemoveAllListeners();
        }

        protected void Start()
        {
            if(Operation == Operation.Edit)
                SetupInputField();
        }

        protected virtual void SetupInputField()
        {
            _surnameField.text = HumanToEdit.Surname;
            _nameField.text = HumanToEdit.Name;
            _patronomycField.text = HumanToEdit.Patronomyc;
            _birthdayField.text = HumanToEdit.Birthday.ToString("dd.MM.yyyy");
        }
        
        private void AcceptButton()
        {
            switch (Operation)
            {
                case Operation.Add:
                    AddHuman();
                    break;
                case Operation.Edit:
                    EditHuman();
                    break;
                default:
                    break;
            }
        }  
        
        protected virtual void AddHuman()
        {
            Surname = _surnameField.text;
            Name =  _nameField.text;
            Patronomyc = _patronomycField.text;
            Birthday = DateTime.Parse(_birthdayField.text);
        }

        protected virtual void EditHuman()
        {
            HumanToEdit.Surname = _surnameField.text;
            HumanToEdit.Name = _nameField.text;
            HumanToEdit.Patronomyc = _patronomycField.text;
            HumanToEdit.Birthday = DateTime.Parse(_birthdayField.text);
        }
        
        protected void OkButton()
        {
            if(Operation != Operation.Delete)
                PageManager.Instance.Close();
        }
    }
}