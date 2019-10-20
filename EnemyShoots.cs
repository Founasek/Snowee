using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoots : MonoBehaviour
{
    [Header("General")]
    public GameObject projectile;
    public bool EnemycanShoot;
    public bool EnemyShoot;
    public float EnemyShootCooldown = 1f;
    public float shootTime = 2f;
    public float DestroyBullet = 1f;

    [Header("Bullet Speed & Height")]
    public Vector2 velocity;
    public Vector2 offset = new Vector2(0f, -0.8f);

  



    
    void Start()
    {
        
        InvokeRepeating("EnemyShooting", 1f, shootTime);
       

    }

    // Update is called once per frame
    void Update()
    {
        
        {
            if (EnemyShoot && EnemycanShoot)
            {

                // Vystřelení střely a připravení další
                GetComponent<Animator>().SetTrigger("Enemy_Shoots");

               
                        GameObject Snowball = (GameObject)Instantiate(projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
                        Snowball.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);


                StartCoroutine(EnemyCanShoot());
                Destroy(Snowball, DestroyBullet);

               
               
            }

           
        }
    }
    
    public void EnemyShooting()
    {
        EnemyShoot = true;
       EnemycanShoot = false;


    }

     IEnumerator EnemyCanShoot()
     {
         EnemycanShoot = false;
         yield return new WaitForSeconds(EnemyShootCooldown);
         EnemycanShoot = true;
        EnemyShooting();
         EnemyShoot = false;  
    }
}
