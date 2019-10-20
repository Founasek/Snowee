using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("General")]
    
    bool isDead;                                                // Whether the player is dead.
    public DeathScript DeathMenu;

    [Header("Health")]
    public int startingHealth = 4;                              // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public int maxhealth = 4;                                   // The maximum health the player can have
    public Image Health1;
    public Image Health2;
    public Image Health3;
    public Image Health4;

    public Image damageImage;
    public float flashSpeed = 30f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

    [Header("Audio")]
    public AudioClip HitSound;
    private AudioSource source;

    [Header("GameOver")]
    public Text CoalFinalcount;
    public Text CoalPickUp;

    public ParticleSystem Particle;

    void Awake()
    {
       
        currentHealth = startingHealth;
        source = GetComponent<AudioSource>();

        Particle = GetComponentInChildren<ParticleSystem>(Particle);
    }
    void Start()
    {
        Health1.enabled = true;
        Health2.enabled = true;
        Health3.enabled = true;
        Health4.enabled = true;
    }

    void Update()
    {
        

        if (currentHealth > maxhealth)
        {
            currentHealth = maxhealth;
        }
       
        if (currentHealth == 4)
        {
            Health1.enabled = true;
            Health2.enabled = true;
            Health3.enabled = true;
            Health4.enabled = true;
            
        }
        

        if (currentHealth == 3)
        {
            Health1.enabled = true;
            Health2.enabled = true;
            Health3.enabled = true;
            Health4.enabled = false;
           
        }
        

        if (currentHealth == 2)
        {
            Health1.enabled = true;
            Health2.enabled = true;
            Health3.enabled = false;
            Health4.enabled = false;
           
        }
       

        if (currentHealth == 1)
        {
            Health1.enabled = true;
            Health2.enabled = false;
            Health3.enabled = false;
            Health4.enabled = false;
           
        }
       
        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            Health1.enabled = false;
            Health2.enabled = false;
            Health3.enabled = false;
            Health4.enabled = false;
            Death();
            
            damageImage.enabled = false;
            
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currentHealth -= 10;
            //other.gameObject.SetActive(false);
            damageImage.color = flashColour;

            if (PlayerPrefs.GetInt("vibrateOff", 0) == 0)
            {
                Handheld.Vibrate();
            }
           
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        if (other.gameObject.tag == "Damage")
        {
            other.gameObject.SetActive(false);
            currentHealth -= 1;
           
           
            source.PlayOneShot(HitSound);
            damageImage.color = flashColour;
            if (PlayerPrefs.GetInt("vibrateOff", 0) == 0)
            {
                Handheld.Vibrate();

            }
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear , flashSpeed * Time.deltaTime);
        }

        if (other.gameObject.tag == "Life")
        {
            currentHealth += 1;
            other.gameObject.SetActive(false);
        }
    }

    void Death()
    {
        isDead = true;
        ParticlePlay();
        CoalFinalcount.text = CoalPickUp.text + " collected coals";
        this.gameObject.SetActive(false);
        DeathMenu.gameObject.SetActive(true);
       Time.timeScale = 0;
    }


    public void ParticlePlay()
    {
        Particle.Play();
        Particle.transform.parent = null; // detach particle system from parent
       
    }
}