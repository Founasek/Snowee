using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{

    [Header("Enemies")]
    public HeadlessEnemyHealth theEnemyHealth;
    public HeadlessEnemyHealth theHeadlessEnemyHealth;
    public HeadlessEnemyHealth theHeadlessEnemyHealth2;

   
    // Respawn nepřítele při projetí collideru v prostředním obrázku
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            theEnemyHealth.NewEnemy();
            theHeadlessEnemyHealth.NewEnemy();
            theHeadlessEnemyHealth2.NewEnemy();
        }
    }
}