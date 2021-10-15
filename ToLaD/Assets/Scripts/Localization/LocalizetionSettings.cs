using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.IO;

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

#if UNITY_EDITOR

        [ContextMenu("CSV/Export")]
        public void ExportCSV()
        {
            var path = UnityEditor.EditorUtility.SaveFilePanel("Save Localization as CSV", "", "Loc.csv", "csv");

            var dict = new Dictionary<string, Dictionary<string, string>>();
            var langFiles = SupportedLanguage.Select(x => x.ResoruceFile).Distinct().ToArray();

            foreach(var langFile in langFiles)
            {
                var resource = Resources.Load<LocalizationResource>(langFile);
                if(resource.Terms == null)
                {
                    continue;
                }

                foreach (var term in resource.Terms)
                {
                    if(!dict.TryGetValue(term.key, out var subDict))
                    {
                        dict[term.key] = subDict = new Dictionary<string, string>();
                    }
                    subDict[langFile] = term.Value;
                }
            }

            StringBuilder csv = new StringBuilder();
            csv.Append("key;").AppendLine(string.Join(";", langFiles));

            foreach(var kvp in dict)
            {
                var line = new string[langFiles.Length + 1];
                line[0] = kvp.Key;

                for(int i = 0; i < langFiles.Length; i++)
                {
                    var langFile = langFiles[i];
                    if(kvp.Value.ContainsKey(langFile))
                    {
                        line[i + 1] = kvp.Value[langFile];
                    }
                    else
                    {
                        line[i + 1] = string.Empty;
                    }
                }
                csv.AppendLine(string.Join(";", line));
            }

            File.WriteAllText(path, csv.ToString(), Encoding.Unicode);
        }

        [ContextMenu("CSV/Import")]
        public void ImportCSV()
        {
            var path = UnityEditor.EditorUtility.OpenFilePanel("Save Localization as CSV", "", "csv");
            var fileContent = File.ReadAllLines(path);
            var headers = fileContent[0].Split(';');
            var mapping = new Dictionary<string, int>(headers.Length);
            for(int i = 1; i < headers.Length; i++)
            {
                mapping[headers[i]] = i;
            }

            var dict = new Dictionary<string, Dictionary<string, string>>();
            for (int i = 1; i < fileContent.Length; ++i)
            {
                var line = fileContent[i].Split(';');
                var key = line[0];
                var value = new Dictionary<string, string>();
                foreach (var map in mapping)
                {
                    value[map.Key] = line[map.Value];
                }
                dict[key] = value;
            }
            for (int i = 1; i < headers.Length; ++i)
            {
                var lang = headers[i];
                var resources = Resources.Load<LocalizationResource>(lang);
                resources.Terms = new List<LocalizationTerm>(dict.Count);
                foreach (var kvp in dict)
                {
                    resources.Terms.Add(
                        new LocalizationTerm()
                        {
                            key = kvp.Key,
                            Value = kvp.Value[lang]
                        });
                }
            }
        }


        private void OnValidate()
        {
            if(SupportedLanguage.Length == 0)
            {
                CreateDefaultLanguage();
            }
            CheckAllLanguages();
        }

        [ContextMenu("Check All Terms")]
        private void CheckAllTerms()
        {
            Dictionary<SystemLanguage, HashSet<string>> keys = new Dictionary<SystemLanguage, HashSet<string>>();
            HashSet<string> uniqueKeys = new HashSet<string>();
            foreach (var lang in SupportedLanguage)
            {
                var file = Resources.Load<LocalizationResource>(lang.ResoruceFile);
                keys[lang.Language] = new HashSet<string>();
                if (file.Terms == null)
                    continue;
                foreach(var term in file.Terms)
                {
                    uniqueKeys.Add(term.key);
                    keys[lang.Language].Add(term.key);
                }
            }
            foreach(var langPair in keys)
            {
                var keySet = langPair.Value;
                keySet.SymmetricExceptWith(uniqueKeys);
                if(keySet.Count !=0)
                {
                    foreach(var key in keySet)
                    {
                        Debug.LogWarning($"Key <b>{key}</b> not found in {langPair.Key}");
                    }
                }
            }
        }

        private void CheckAllLanguages()
        {
            HashSet<SystemLanguage> usedLanguags = new HashSet<SystemLanguage>();
            foreach (var lang in SupportedLanguage)
            {
                if(!IsExists(lang.ResoruceFile))
                {
                    lang.ResoruceFile = CreateNewResource(lang.Language);
                }

                if(usedLanguags.Contains(lang.Language))
                {
                    Debug.LogWarning($"{lang.Language} already in use. Please fix");
                }
                else
                {
                    usedLanguags.Add(lang.Language);
                }
            }
        }

        private string CreateNewResource(SystemLanguage language)
        {
            var name = $"loc_{language.ToString().ToLower()}";

            if(!IsExists(name))
            {
                UnityEditor.AssetDatabase.CreateAsset(
                    CreateInstance<LocalizationResource>(),
                    $"Assets/Resources/{name}.asset");
                UnityEditor.AssetDatabase.SaveAssets();
            }
            return name;
        }

        private bool IsExists(string resoruceFile)
        {
            return Resources.Load<LocalizationResource>(resoruceFile) != null;
        }

        private void CreateDefaultLanguage()
        {
            DefaultLanguage = Application.systemLanguage;
            SupportedLanguage = new SupportedLanguage[]
            {
                new SupportedLanguage
                {
                    Language = DefaultLanguage
                }
            };
        }
#endif
    }
}

