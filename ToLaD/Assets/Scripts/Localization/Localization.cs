using Assets.Scripts;
using System.Linq;
using System;
using UnityEngine;
using System.Collections.Generic;

public static class Localization
{
    private static ILookup<string, string> _termsMap;

    public static SystemLanguage CurrentLanguage { get; private set; }

    public static bool IsLoad => _termsMap != null;

    public static void Load()
    {
        var lang = PlayerPrefs.GetString(LocalizetionSettings.Instance.PrefKey, null);
        if(!Enum.TryParse(lang, out SystemLanguage localizationLanguage))
        {
            CurrentLanguage = localizationLanguage;
        }
        else
        {
            CurrentLanguage = DetectLanguage();
        }

        LoadTermsMap();
    }

    private static void LoadTermsMap()
    {
        var language = LocalizetionSettings.Instance.SupportedLanguage.First(x => x.Language == CurrentLanguage);
        var resource = Resources.Load<LocalizationResource>(language.ResoruceFile);

        _termsMap = resource.Terms.ToLookup(item => item.key, item => item.Value);
    }

    private static SystemLanguage DetectLanguage()
    {
        var systemLanguage = Application.systemLanguage;
        foreach (var lang in LocalizetionSettings.Instance.SupportedLanguage)
        {
            if(lang.Language == systemLanguage)
            {
                return lang.Language;
            }
        }
        return LocalizetionSettings.Instance.DefaultLanguage;
    }

    internal static string GetTerm(string key, Dictionary<string, string> parameters = null)
    {
        if(string.IsNullOrEmpty(key))
        {
            return string.Empty;
        }

        if(!IsLoad)
        {
            Load();
        }

        var result = _termsMap[key].FirstOrDefault();
        if(result != null)
        {
            if(parameters != null && parameters.Count > 0)
            {
                parameters.Aggregate(result, (current, parameter) => current.Replace($"%{parameter.Key}%", parameter.Value));
            }
            return result;
        }

        return $">> {key} <<";
    }

    public static void SetLanguage(SystemLanguage lang)
    {
        PlayerPrefs.SetString(LocalizetionSettings.Instance.PrefKey, lang.ToString());
        PlayerPrefs.Save();
    }
}
