using UnityEditor;

public class EditorMenu
{
    [MenuItem("Game/Localization/English")]
    public static void SetLanguagEnglish()
    {
        Localization.SetLanguage(UnityEngine.SystemLanguage.English);
        UpdateCheckBox();
    }

    [MenuItem("Game/Localization/Russian")]
    public static void SetLanguagRussian()
    {
        Localization.SetLanguage(UnityEngine.SystemLanguage.Russian);
        UpdateCheckBox();
    }

    [MenuItem("Game/Localization/Reload", priority = 200)]
    public static void ReloadLocalization()
    {
        Localization.Load();
    }

    private static void UpdateCheckBox()
    {
        Menu.SetChecked("Game/Localization/English", Localization.CurrentLanguage == UnityEngine.SystemLanguage.English);
        Menu.SetChecked("Game/Localization/Russian", Localization.CurrentLanguage == UnityEngine.SystemLanguage.Russian);
    }

    [InitializeOnLoadMethod]
    public static void LoadCheckBoxes()
    {
        EditorApplication.delayCall += UpdateCheckBox;
    }
}
