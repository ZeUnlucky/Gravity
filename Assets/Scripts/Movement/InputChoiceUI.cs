using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputChoiceUI : MonoBehaviour
{
    public GameObject InputChoicePanel;
    public Button SwipeButton;
    public Button ButtonButton;

    void Start()
    {
        if (!PlayerPrefs.HasKey("InputChoice"))
        {
            InputChoicePanel.SetActive(true);

        }

        else
        {
            InputChoicePanel.SetActive(false);
            LoadInputChoice();
        }

        SwipeButton.onClick.AddListener(() => setInputChoice("Swipe"));
        ButtonButton.onClick.AddListener(() => setInputChoice("Button"));

    }

    private void setInputChoice (string choice)
    {
        PlayerPrefs.SetString("InputChoice", choice);
        PlayerPrefs.Save();
        InputChoicePanel.SetActive(false);
        LoadInputChoice();
    }

    private void LoadInputChoice()
    {
        string choice = PlayerPrefs.GetString("InputChoice");
        if (choice == "Swipe")
        {
            PlayerPrefs.SetInt("UseButtons", 0);
        }

        else if (choice == "Buttons")
        {
            PlayerPrefs.SetInt("UseButtons", 1);
        }

    }
}
