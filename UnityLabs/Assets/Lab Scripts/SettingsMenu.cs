using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public bool Hard = false;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetHardMode(bool isHard)
    {
        if (isHard)
        {
            PlayerPrefs.SetInt("isHard", 1);
        } else
        {
            PlayerPrefs.SetInt("isHard", 0);
        }
    }
}
