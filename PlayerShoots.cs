using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoots : MonoBehaviour
{

    [Header("General")]
    public GameObject projectile;
    public bool Shoot;
    public bool canShoot = true;
    public float cooldown = 1f;
    

    [Header("Bullet Speed, High & Life")]
    public Vector2 velocity;
    public Vector2 offset = new Vector2(0.4f, 0.1f);
    [Range(0f, 5f)]
    public float DestroyBullet = 3f;




    void Start()
    {
        canShoot = true;
    }
    void Update()
    {
        if (Shoot && canShoot)
        {
            GetComponent<Animator>().SetTrigger("Player_shoot");
                     
            // Vystřelení střely
            GameObject carrot = (GameObject)Instantiate(projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
            carrot.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);
            StartCoroutine(CanShoot());

            // Zničení střely
            Destroy(carrot, DestroyBullet);
        }
    }

    public void Shooting()
    {
        Shoot = true;
    }

    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
        Shoot = false;
    }
}

