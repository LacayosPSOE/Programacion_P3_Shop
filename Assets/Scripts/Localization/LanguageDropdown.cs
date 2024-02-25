using System;
using TMPro;
using UnityEngine;

public class LanguageDropdown : MonoBehaviour
{
    private TMP_Dropdown _dropdown;

    private void Start()
    {
        _dropdown = GetComponent<TMP_Dropdown>();
    }

    public void OnDropdownChange()
    {
        if (_dropdown == null) _dropdown = GetComponent<TMP_Dropdown>();

        var _option = _dropdown.options[_dropdown.value].text;
        var _language = Enum.Parse<Language>(_option);
        Localizer.SetLanguage(_language);
    }
}
