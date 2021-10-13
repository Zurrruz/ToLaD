using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Localization_settings.asset", menuName = "Localization/Create Settings")]
    public class LocalizetionSettings : ScriptableObject
    {
        private static LocalizetionSettings _instance;

        public static LocalizetionSettings Instance
        {
            get
            {
                if (_instance is null)
                    _instance = Resources.Load<LocalizetionSettings>("localization_settings");
                return _instance;
            }            
        }

        public string PrefKey = "lang";
        public SystemLanguage DefaultLanguage = SystemLanguage.English;
        public SupportedLanguage[] SupportedLanguage;
    }
}

