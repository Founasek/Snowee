using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPools : MonoBehaviour
{

    [Header("Coal")]
    public GameObject Coal;
    public GameObject Coal1;
    public GameObject Coal2;
    public GameObject Coal3;
    public GameObject Coal4;
    public GameObject Coal5;
    public GameObject Coal6;
    public GameObject Coal7;
    public GameObject Coal8;

    [Header("Obstacles")]
    public GameObject Fire;
    public GameObject Wood;
    public GameObject Stone;
    [Header("Power Ups")]
    public GameObject Heart;

    

   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            

            Coal.SetActive(true);
            Coal1.SetActive(true);
            Coal2.SetActive(true);
            Coal3.SetActive(true);
            Coal4.SetActive(true);
            Coal5.SetActive(true);
            Coal6.SetActive(true);
            Coal7.SetActive(true);
            Coal8.SetActive(true);
            Fire.SetActive(true);
            Wood.SetActive(true);
            Stone.SetActive(true);
        
            int Life = Random.Range(1, 6);
            {

                switch (Life)

                {
                    case 1:
                        Debug.Log("LIFE");
                        Heart.SetActive(true);
                        break;
                    case 2:
                       
                        Heart.SetActive(false);
                        break;
                    case 3:
                       
                        Heart.SetActive(false);
                        break;
                    case 4:
                        
                        Heart.SetActive(false);
                        break;
                    case 5:
                        Debug.Log("LIFE");
                        Heart.SetActive(true);
                        break;
                    
                }



            }
        }

    }
}
