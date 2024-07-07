using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVolumeForThisObject : MonoBehaviour
{
    private new AudioSource audio;
    // Start is called before the first frame update
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefs.GetFloat("VolumePref", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = PlayerPrefs.GetFloat("VolumePref", 0.5f);
    }
}
