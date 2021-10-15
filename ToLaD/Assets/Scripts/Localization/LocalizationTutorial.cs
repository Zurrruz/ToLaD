using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LocalizationTutorial : MonoBehaviour
    {
        private Dictionary<string, string> _parameters;
        [SerializeField]
        private TextMeshProUGUI _textMeshPro;
        [SerializeField]
        public static string key;


        public string Key
        {
            get => key;
            set
            {
                key = value;
                UpdateTerms();
            }
        }

        private void Awake()
        {
            if (_textMeshPro is null)
            {
                _textMeshPro = GetComponent<TextMeshProUGUI>();
            }
        }

        private void OnValidate()
        {
            if (_textMeshPro is null)
            {
                _textMeshPro = GetComponent<TextMeshProUGUI>();
            }
            UpdateTerms();
        }

        private void OnEnable()
        {
            Localization.OnLanguageChanged += UpdateTerms;
            UpdateTerms();
        }

        private void OnDisable()
        {
            Localization.OnLanguageChanged -= UpdateTerms;
        }

        private void UpdateTerms()
        {
            _textMeshPro.font = Localization.SuggestedFont;
            _textMeshPro.text = Localization.GetTerm(key, _parameters);
        }

        public void SetParameters(Dictionary<string, string> parameters)
        {
            _parameters = parameters;
            UpdateTerms();
        }
    }
}

