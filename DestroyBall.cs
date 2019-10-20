using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour {


    [Header("Other scripts")]
    public HeadlessEnemyHealth Enemy1Health;
    public HeadlessEnemyShoots Enemy1Shoots;

    public HeadlessEnemyHealth Enemy2Health;
    public HeadlessEnemyShoots Enemy2Shoots;

    public HeadlessEnemyHealth Enemy3Health;
    public HeadlessEnemyShoots Enemy3Shoots;

    // Update is called once per frame
    void Update ()
    {

        if (Enemy1Health.HeadLessEnemy.activeSelf == false)
        {
            Destroy(GameObject.Find("Snowball_Bullet(Clone)"));
            Destroy(GameObject.Find("Snowball_Bullet(Clone)(1)"));
        }

        if (Enemy2Health.HeadLessEnemy.activeSelf == false)
        {

            Destroy(GameObject.Find("Snowball_Bullet 1(Clone)")); 
            Destroy(GameObject.Find("Snowball_Bullet 1(Clone)(1)"));
        }

        if (Enemy3Health.HeadLessEnemy.activeSelf == false)
        {

            Destroy(GameObject.Find("Snowball_Bullet 1(Clone)"));
            Destroy(GameObject.Find("Snowball_Bullet 1(Clone)(1)"));
        }
    }
}
