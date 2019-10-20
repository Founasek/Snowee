using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadlessEnemyShoots : MonoBehaviour {

    public GameObject Enemy;
    public GameObject projectile;
    public Vector2 velocity;
    public Vector2 offset = new Vector2(0f, -0.8f);
   public float shootTime = 1.5f;
    public float DestroyBullet = 1.5f;


    void Start()
    {

         InvokeRepeating("EnemyShooting", 1f, shootTime);

        
    }

  

    public void EnemyShooting()
    {


        // Vystřelení střely, připravení další a zničení


        if (this.gameObject.activeSelf)
        {
            GameObject Snowball = (GameObject)Instantiate(projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
            Snowball.transform.parent = Enemy.transform;
            Snowball.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);

            Destroy(Snowball, DestroyBullet);

            
        }
       
        

    }
    
    
}
