using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Localization.asset", menuName = "Localization/Create Resource")]
    public class LocalizationResource : ScriptableObject
    {
        public TMP_FontAsset Font;
        public List<LocalizationTerm> Terms;        
    }

    [System.Serializable]
    public class LocalizationTerm
    {
        public string key;
        public string Value;
    }
}