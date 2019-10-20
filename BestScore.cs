using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class BestScore : MonoBehaviour {

    public Text highScore;
    

	// Use this for initialization
	void Start ()

    {


        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.DeleteKey("vibrateOff");
        PlayerPrefs.DeleteKey("AudioOff");


         highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
       
        Analytics.CustomEvent("BestScore", new Dictionary<string, object>
        {
            { "Score", highScore.text }
        });

    }
}
