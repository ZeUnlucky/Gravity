using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DailyRewards : MonoBehaviour
{
    public GameObject DailyRewardsCanvas;
    public TMP_Text RewardText;  // ui to display reward
    public int[] RewardValues; // array containing the rewards for each day
    public int maxStreak = 7; // max consecutive days tracked

    private int currentStreak = 0;
    private DateTime lastLoginDate;
    // Start is called before the first frame update
    void Start()
    {
        LoadDailyRewards();
        CheckDailyRewards();
    }

    void LoadDailyRewards()
    {
        if (PlayerPrefs.HasKey("LastLoginDate"))
        {
            // last login day
            lastLoginDate = DateTime.Parse(PlayerPrefs.GetString("LastLoginDate"));

        }
        else
        {
            lastLoginDate= DateTime.Now.AddDays(-1);  //Initialize to yesterday
        }

        // load streak
        currentStreak = PlayerPrefs.GetInt("CurrentStreak", 0);
    }

    void CheckDailyRewards()
    {
        DateTime currentDate= DateTime.Now;
        int daysDifference= (currentDate -  lastLoginDate).Days;
        if (daysDifference < 2) // if it's lower than 2 because always "1" day passed as it rounds up
            currentStreak = 1;
        else
        {
            Debug.Log(daysDifference + " and " + currentStreak);
            currentStreak = daysDifference == 2 ? currentStreak+1 : 1; // if it's equal 2 because always "1" day passed as it rounds up
            Debug.Log(daysDifference + " and " + currentStreak);
            if (currentStreak > maxStreak) currentStreak = maxStreak;

            //save new login date and streak
            Debug.Log(currentStreak);
            lastLoginDate = currentDate;
            PlayerPrefs.GetString("LastLoginDate", lastLoginDate.ToString());
            PlayerPrefs.SetInt("CurrentStreak", currentStreak);
            ShowStreakUI();
        }



       
    }

    void ShowStreakUI()
    {
        DailyRewardsCanvas.SetActive(true);

        // give reward

        int reward = RewardValues[currentStreak - 1];
        RewardText.text = "Today's Reward: " + reward.ToString();
    }

    public void GiveReward()
    {
        int currentCoins = PlayerPrefs.GetInt("PlayerCoins", 0);
        Debug.Log(currentStreak);
        int todaysReward = RewardValues[currentStreak-1];
        PlayerPrefs.SetInt("PlayerCoins", currentCoins + todaysReward);
        DailyRewardsCanvas.SetActive(false);
    }
   
}
