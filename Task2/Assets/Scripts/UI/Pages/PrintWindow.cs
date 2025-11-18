// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;
using Entities;

namespace UI.Pages
{
    public class PrintWindow : BaseWindow
    {
        [SerializeField] private Button _nextStepButton;
        [SerializeField] private Button _prevStepButton;
        [SerializeField] private Button _okButton;

        [SerializeField] private Text _outputText;
        [SerializeField] private Text _countText;
        
        public override void OnOpen(object data)
        {
           _nextStepButton.onClick.AddListener(NextStep);
           _prevStepButton.onClick.AddListener(PrevStep);
           _okButton.onClick.AddListener(OkButton);
           HumansList.OnHumansChanged += UpdateDisplay;
           HumansList.Index = 0;
           UpdateDisplay();
        }

        public override void OnClose(object data)
        {
            _nextStepButton.onClick.RemoveAllListeners();
            _prevStepButton.onClick.RemoveAllListeners();
            _okButton.onClick.RemoveAllListeners();
            HumansList.OnHumansChanged -= UpdateDisplay;
        }

        private void UpdateDisplay()
        {
            _outputText.text = HumansList.PrintHuman();
            if (HumansList.Count() == 0)
            {
                _countText.text = $"{HumansList.Index}/{HumansList.Count()}";
                _nextStepButton.gameObject.SetActive(false);
                _prevStepButton.gameObject.SetActive(false);
                _countText.gameObject.SetActive(false);
            }
            else
            {
                _nextStepButton.gameObject.SetActive(true);
                _prevStepButton.gameObject.SetActive(true);
                _countText.gameObject.SetActive(true);
                _countText.text = $"{HumansList.Index + 1}/{HumansList.Count()}";
            }
        }

        public void NextStep()
        {
            if (HumansList.Index == HumansList.Count() - 1)
                HumansList.Index = 0;
            else
                HumansList.Index++;
        }

        public void PrevStep()
        {
            if (HumansList.Index == 0)
                HumansList.Index = HumansList.Count() - 1;
            else
                HumansList.Index--;
        }

        public void OkButton()
        {
            PageManager.Instance.Close();
        }
    }
}