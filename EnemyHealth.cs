using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    [Header("Enemy Health")]
    public GameObject Enemy;
    public int startingEnemyHealth = 3;                            // The amount of health the player starts the game with.
    public int currentEnemyHealth;                                   // The current health the player has.
    public Image EnemyHealth1;
    public Image EnemyHealth2;
    public Image EnemyHealth3;
    
    [Header("Particle System")]
    public ParticleSystem Boomy;
    [Header("Score per kill")]
    public PlayerPickup thePlayerPickup;

    void Awake()
    {
        Boomy = GetComponentInChildren<ParticleSystem>(Boomy);
        
    }
    void Start()
    {
        Enemy.SetActive(true);
        currentEnemyHealth = startingEnemyHealth;
    }

    void Update()
    {

       
        switch (currentEnemyHealth)
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
        Enemy.SetActive(false);
       
        thePlayerPickup.CountEnemyKill();
    }
    public void BoomyPartPlay()
    {
        Boomy.Play();
        Boomy.transform.parent = null; // detach particle system from parent
    }
    public void NewEnemy()
    {
        //attach particle system to parent
        Boomy.transform.parent = Enemy.transform;
        //Set right position of particle system
        Boomy.transform.position = Enemy.transform.position;
        currentEnemyHealth = startingEnemyHealth;
        Enemy.SetActive(true);
       
    }

    // Ubírá zdraví, když Player vystřelí po nepříteli
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Carrot")
        {
            currentEnemyHealth -= 1;
            other.gameObject.SetActive(false);
            
        }
    }

    
}
