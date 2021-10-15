using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LocalizationButton : MonoBehaviour
{
    private int english = 1;
    private int russian = 2;
    public void EngButton()
    {
        Localization.SetLanguage(UnityEngine.SystemLanguage.English);
        UpdateCheckBox();
        PlayerPrefs.SetInt("lang", english);
        PlayerPrefs.Save();
    }

    public void RusButton()
    {
        Localization.SetLanguage(UnityEngine.SystemLanguage.Russian);
        UpdateCheckBox();
        PlayerPrefs.SetInt("lang", russian);
        PlayerPrefs.Save();
    }

    private static void UpdateCheckBox()
    {
        Menu.SetChecked("Game/Localization/English", Localization.CurrentLanguage == UnityEngine.SystemLanguage.English);
        Menu.SetChecked("Game/Localization/Russian", Localization.CurrentLanguage == UnityEngine.SystemLanguage.Russian);
    }
}
