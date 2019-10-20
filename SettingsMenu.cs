using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour {

    public GameObject Settings;
    public GameObject Tutorial;
    public Text HowToPlay;
    public Image Settings_bt;




    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenSettings()
    {
        Settings.SetActive(true);
        HowToPlay.enabled = true;
        Tutorial.SetActive(false);
        Settings_bt.enabled = false;
    }
    public void ExitSettings()
    {
        Settings.SetActive(false);
        Settings_bt.enabled = true;
    }

    public void OpenTutorial()
    {
        Tutorial.SetActive(true);
        HowToPlay.enabled = false;
        Settings.SetActive(false);
    }
    public void ExitTutorial()
    {
        Tutorial.SetActive(false);
        HowToPlay.enabled = true;
        Settings.SetActive(true);



    }
}
