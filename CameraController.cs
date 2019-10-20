using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    
    public GameObject Player;
    private Vector3 lastPlayerposition;
    private float distancetoMove;

    // Use this for initialization
    void Awake()
    {
        // Telefon se neztmaví a nezakmne se
        Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
    }

    void Start () {
        

        lastPlayerposition = Player.transform.position;
	}

    // Update is called once per frame
	void Update () {
        distancetoMove = Player.transform.position.x - lastPlayerposition.x;
        transform.position = new Vector3(transform.position.x + distancetoMove, transform.position.y, transform.position.z);
        lastPlayerposition = Player.transform.position;
	}
}
