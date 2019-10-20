using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour {

    [Header("General")]
    public Text PickUpText;
    public int CountPickUps;
 
   
	void Start ()
    {
        CountPickUps = 0;
        SetCountText();
      
    }
	
	// PickUp Coal
	void OnTriggerEnter2D(Collider2D other)
    {
		if(other.gameObject.tag == "Coal")
        {
            other.gameObject.SetActive(false);
            CountPickUps = CountPickUps + 1;
            SetCountText();
        }
	}
   //Zobrazuje text počtu sebraných uhlíků
   public void SetCountText()
    {
        PickUpText.text = CountPickUps.ToString();

        if(CountPickUps > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", CountPickUps);
        }
       

    }

    public void CountEnemyKill()
    {
        CountPickUps = CountPickUps + 10;
        SetCountText();

    }
}
