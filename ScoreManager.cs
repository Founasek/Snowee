using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public float scoreCount;
    public bool scoreIncreasing;
    public float pointsPerSecond;



	void Start ()
    {
        scoreIncreasing = true;
	}

	void Update ()
    {
        if (scoreIncreasing)
        { 
        scoreCount += pointsPerSecond * Time.deltaTime;
            int min = Mathf.FloorToInt(scoreCount / 60);
            int sec = Mathf.FloorToInt(scoreCount % 60);

            scoreText.text = "" + min.ToString("00") + ":" + sec.ToString("00");
           
        }
	}
}

  