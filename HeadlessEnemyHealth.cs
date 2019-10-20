using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadlessEnemyHealth : MonoBehaviour {

    [Header("Enemy Health")]
    public GameObject HeadLessEnemy;
    public int startingHeadLessEnemyHealth = 3;                            // The amount of health the player starts the game with.
    public int currentHeadLessEnemyHealth;                                   // The current health the player has.
    public Image EnemyHealth1;
    public Image EnemyHealth2;
    public Image EnemyHealth3;
    public ParticleSystem Boomy;
    [Header("Score per kill")]
    public PlayerPickup thePlayerPickup;

    public GameObject DeathSound;
    



    void Awake()
    {
        Boomy = GetComponentInChildren<ParticleSystem>(Boomy);
       

    }
    void Start()
    {
        HeadLessEnemy.SetActive(true);
        currentHeadLessEnemyHealth = startingHeadLessEnemyHealth;
    }

    void Update()
    {


        switch (currentHeadLessEnemyHealth)
        {
            case 3:
                EnemyHealth1.enabled = true;
                EnemyHealth2.enabled = true;
                EnemyHealth3.enabled = true;
                break;

            case 2:
                EnemyHealth1.enabled = true;
                EnemyHealth2.enabled = true;
                EnemyHealth3.enabled = false;
                break;
            case 1:
                EnemyHealth1.enabled = true;
                EnemyHealth2.enabled = false;
                EnemyHealth3.enabled = false;
                break;
            case 0:
                EnemyHealth1.enabled = false;
                EnemyHealth2.enabled = false;
                EnemyHealth3.enabled = false;
                DeathEnemy();
                break;
        }
    }

    void DeathEnemy()
    {
       
        // Enemy ztratil zdraví a zemřel
        BoomyPartPlay();
        HeadLessEnemy.SetActive(false);
        thePlayerPickup.CountEnemyKill();
        DeathSound.SetActive(true);
        
        
    }
    public void BoomyPartPlay()
    {
        Boomy.Play();
        Boomy.transform.parent = null; // detach particle system from parent
        DeathSound.transform.parent = null;
    }
    public void NewEnemy()
    {
        //attach particle system to parent
        Boomy.transform.parent = HeadLessEnemy.transform;
        DeathSound.transform.parent = HeadLessEnemy.transform;
        //Set right position of particle system
        Boomy.transform.position = HeadLessEnemy.transform.position;
        DeathSound.transform.position = HeadLessEnemy.transform.position;
        currentHeadLessEnemyHealth = startingHeadLessEnemyHealth;
        HeadLessEnemy.SetActive(true);
        DeathSound.SetActive(false);

    }

    // Ubírá zdraví, když Player vystřelí po nepříteli
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Carrot")
        {
        
            currentHeadLessEnemyHealth -= 1;
            other.gameObject.SetActive(false);
            
        }
    }
}

