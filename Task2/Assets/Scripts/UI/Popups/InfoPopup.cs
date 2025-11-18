// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;
using Entities;

namespace UI.Popups
{
    public class InfoPopup : BasePopup
    {
        [SerializeField] private Button _okButton;
        [SerializeField] private Text _text;

        private string _surname;
        
        protected void Awake()
        {
            _okButton.onClick.AddListener(OkClick);
        }

        public override void OnOpen(object data)
        {
            base.OnOpen(data);
        
            if (data is DataMember dataMember)
            {
                _surname = dataMember.Surname;
                Operation = dataMember.Operation;
            }
            
            gameObject.SetActive(true);
            ViewDisplay();
        }

        private void ViewDisplay()
        {
            switch (Operation)
            {
                case Operation.Add:
                    _text.text =  $"Человек с фамилией {_surname} добавлен!";
                    break;
                case Operation.Edit:
                    _text.text = $"Человек с фамилией {_surname} изменен!";
                    break;
                case Operation.Delete:
                    _text.text = $"Человек с фамилией {_surname} удален!";
                    break;
                case Operation.Error:
                    _text.text = "Ошибка заполнения данных! Попробуйте заново!";
                    break;
                default:
                    _text.text = "Ничего не произошло!";
                    break;
            }
        }
    }
}