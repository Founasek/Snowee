using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [Header("General")]

    
    public GameObject PauseScreen;
    public bool isPaused = false;

    

    public void Pause()
    {
        isPaused = true;
        PauseScreen.SetActive(true);
        AudioListener.volume = 0.3f;
        Time.timeScale = 0;
        
        
    }

    public void ResumeGame()
    {
        isPaused = false;
        PauseScreen.SetActive(false);
        AudioListener.volume = 1f;
        Time.timeScale = 1;
        
        
    }

    public void MainMenu()
    {
        AudioListener.volume = 1f;
        SceneManager.LoadScene("MainMenu");

    }

    void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;
        Pause();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
        Pause();
    }
}

