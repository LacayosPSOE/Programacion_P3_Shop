using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Localizer : MonoBehaviour
{
    public static Localizer Instance;

    Dictionary<string, LanguageData> Data;
    private Language _currentLanguage;
    public Language DefaultLanguage;

    public TextAsset DataSheet;
    
    public delegate void LanguageChangeDelegate();
    public static LanguageChangeDelegate OnLanguageChangeDelegate;

    private void Awake()
    {
        Instance = this;
        LoadLanguageSheet();
        
        if (PlayerPrefs.HasKey("language"))
            _currentLanguage = Enum.Parse<Language>(PlayerPrefs.GetString("language"));
        else
            _currentLanguage = DefaultLanguage;
    }

    public static string GetText(string textKey)
    {
        return Instance.Data[textKey].GetText(Instance._currentLanguage);
    }

    public static void SetLanguage(Language language)
    {
        Instance._currentLanguage = language;
        OnLanguageChangeDelegate?.Invoke();
    }

    void LoadLanguageSheet()
    {
        string[] lines = DataSheet.text.Split(new char[]{ '\n'});

        for (int i = 1; i < lines.Length; i++)
        {
            if (lines.Length > 1) AddNewDataEntry(lines[i]);
        }
    }

    void AddNewDataEntry(string str)
    {
        string[] entry = str.Split(new char[] { ';' });

        var languageData = new LanguageData(entry);

        if (Data == null) Data = new Dictionary<string, LanguageData>();
        Data.Add(entry[0], languageData);
    }
}
