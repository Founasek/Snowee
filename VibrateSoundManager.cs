using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateSoundManager : MonoBehaviour {

    public GameObject VibrationOnIcon;
    public GameObject VibrationOffIcon;

    public GameObject AudioOnIcon;
    public GameObject AuidoOffIcon;

    void Start()
    {
        SetvibrationState();
        SetAudioState();
    }


    public void ToggleVibration()
    {
        if (PlayerPrefs.GetInt("vibrateOff", 0) == 0)
        {
            PlayerPrefs.SetInt("vibrateOff", 1);
        }
        else
        {
            PlayerPrefs.SetInt("vibrateOff", 0);
        }
        SetvibrationState();
    }

    private void SetvibrationState()
    {
        if (PlayerPrefs.GetInt("vibrateOff", 0) == 0)
        {
            
            VibrationOnIcon.SetActive(true);
            VibrationOffIcon.SetActive(false);
        }
        else
        {
            
            VibrationOnIcon.SetActive(false);
            VibrationOffIcon.SetActive(true);
        }
    }
        public void ToggleSounds()
    {
        if (PlayerPrefs.GetInt("AudioOff", 0) == 0)
        {
            PlayerPrefs.SetInt("AudioOff", 1);
        }
        else
        {
            PlayerPrefs.SetInt("AudioOff", 0);
        }
        SetAudioState();
    }
    private void SetAudioState()
    {
        if (PlayerPrefs.GetInt("AudioOff", 0) == 1)
        {
            AudioListener.volume = 0;
            AudioOnIcon.SetActive(false);
            AuidoOffIcon.SetActive(true);

        }
        else
        {
            AudioListener.volume = 1;
            AudioOnIcon.SetActive(true);
            AuidoOffIcon.SetActive(false);
        }
    }

    public void PauseGame()
    {
        AudioListener.volume = 0.1f;
    }
    public void UnPauseGame()
    {
        AudioListener.volume = 1f;
    }
}


