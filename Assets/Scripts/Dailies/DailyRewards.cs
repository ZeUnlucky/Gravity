using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DailyRewards : MonoBehaviour
{
    public GameObject DailyRewardsCanvas;
    public Text RewardText;  // ui to display reward
    public GameObject[] RewardIcons; // ui icons for each day's reward
    public int[] RewardValues; // array containing the rewards for each day
    public int maxStreak = 7; // max consecutive days tracked

    private int currentStreak;
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

        if (daysDifference == 1) // consecutive login
        {
            currentStreak++;
            if (currentStreak > maxStreak) currentStreak = maxStreak;
            
        }

        else if (daysDifference >1) // missed a day
        {
            currentStreak = 1;
        }


        //save new login date and streak
        lastLoginDate = currentDate;
        PlayerPrefs.GetString("LastLoginDate", lastLoginDate.ToString());
        PlayerPrefs.SetInt("CurrentStreak", currentStreak);


        // give reward

        int reward= RewardValues[currentStreak-1];
        RewardText.text= "Today's Reward: " + reward.ToString();

        UpdateRewardUI();
    }

    void UpdateRewardUI()
    {
        for (int i = 0; i < RewardValues.Length; i++)
        {
            if (i < currentStreak)
            {
                //highlights claim rewards
                RewardIcons[i].SetActive(true);
            }

            else
            {
                RewardIcons[i].SetActive(false);
            }
        }
    }
}
