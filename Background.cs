using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {


    public GameObject BG1;
    public GameObject BG2;
    public GameObject BG3;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("ChangeBackground", 15f, 30f);
	}
	
	// Update is called once per frame
	void Update () {
       

    }

    public void ChangeBackground()
    {

        int BackGround = Random.Range(1, 4);

        switch (BackGround)
        {
            case 1:
                
                BG1.GetComponent<SpriteRenderer>().sprite = Resources.Load("GameImage1", typeof(Sprite)) as Sprite;
                BG2.GetComponent<SpriteRenderer>().sprite = Resources.Load("GameImage1", typeof(Sprite)) as Sprite;
                BG3.GetComponent<SpriteRenderer>().sprite = Resources.Load("GameImage1", typeof(Sprite)) as Sprite;

                break;
            case 2:
               
                   
                BG1.GetComponent<SpriteRenderer>().sprite = Resources.Load("GameImage2", typeof(Sprite)) as Sprite;
                BG2.GetComponent<SpriteRenderer>().sprite = Resources.Load("GameImage2", typeof(Sprite)) as Sprite;
                BG3.GetComponent<SpriteRenderer>().sprite = Resources.Load("GameImage2", typeof(Sprite)) as Sprite;
                break;
            case 3:
                 

                BG1.GetComponent<SpriteRenderer>().sprite = Resources.Load("GameImage3", typeof(Sprite)) as Sprite;
                BG2.GetComponent<SpriteRenderer>().sprite = Resources.Load("GameImage3", typeof(Sprite)) as Sprite;
                BG3.GetComponent<SpriteRenderer>().sprite = Resources.Load("GameImage3", typeof(Sprite)) as Sprite;

                break;
           
        }
    }
}
