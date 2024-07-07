using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class SettingsInputUI : MonoBehaviour
{
    public TMP_Dropdown InputChoiceDropdown;

 
    private void Start()
    {
        LoadInputChoice();
    }

    public void SaveInputChoice(int choiceIndex)
    {
        PlayerPrefs.SetInt("InputChoice", choiceIndex);
        PlayerPrefs.Save();
        ApplyInputChoice(choiceIndex);
    }

    public void LoadInputChoice()
    {
        int choiceIndex = PlayerPrefs.GetInt("InputChoice", 0); // Default to Swipe if not set
        InputChoiceDropdown.value = choiceIndex;
        ApplyInputChoice(choiceIndex);
    }

    private void ApplyInputChoice(int choiceIndex)
    {        
        PlayerPrefs.SetInt("UseButtons", choiceIndex);
    }
}
