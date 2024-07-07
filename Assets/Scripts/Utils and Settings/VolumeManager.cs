using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;
    private const string VolumePrefKey= "VolumePref";

    private void Start()
    {
        if (PlayerPrefs.HasKey(VolumePrefKey))
        {
            float savedVolume= PlayerPrefs.GetFloat(VolumePrefKey);
            AudioListener.volume = savedVolume;
            volumeSlider.value = savedVolume;
        }
        else
        {
            AudioListener.volume = 1.0f;
            volumeSlider.value = 1.0f;
        }

        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat(VolumePrefKey, volume);
        PlayerPrefs.Save();
    }
}
