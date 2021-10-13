using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Localization.asset", menuName = "Localization/Create Resource")]
    public class LocalizationResource : ScriptableObject
    {
        public List<LocalizationTerm> Terms;        
    }

    [System.Serializable]
    public class LocalizationTerm
    {
        public string key;
        public string Value;
    }
}