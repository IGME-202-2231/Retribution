using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameObject Player;   // reference to player
    public Health PlayerHealth;
    public List<GameObject> EnemyList = new List<GameObject>();     // reference to eemies
    public List<GameObject> Bullets = new List<GameObject>();   // reference to bullets

    // Update is called once per frame
    void Update()
    {
        bool isColliding = false;

        foreach (GameObject enemy in EnemyList)                 // PLAYER - ENEMY COLLISIONS
        {
            if (Collisions(Player, enemy))  // collision detected
            {
                isColliding = true;
                enemy.GetComponent<SpriteRenderer>().color = Color.red;
                PlayerHealth.TakeDamage();
                Debug.Log("Colliding");
            }
            else enemy.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (isColliding)
        {
            Player.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            Player.GetComponent<SpriteRenderer>().color = Color.white;
        }



        foreach (GameObject bullet in Bullets)                  // PLAYER BULLET - ENEMY COLLISIONS
        {
            foreach (GameObject enemy in EnemyList)
            {
                if (Collisions(bullet, enemy))
                {
                    isColliding = true;
                    enemy.GetComponent<SpriteRenderer>().color = Color.red;
                    Debug.Log("Colliding");
                }
                else enemy.GetComponent <SpriteRenderer>().color = Color.white;
            }

            if (isColliding)
            {
                bullet.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                bullet.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }

    }

    bool Collisions(GameObject player, GameObject enemies)
    {
        SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
        SpriteRenderer enemyRenderer = enemies.GetComponent<SpriteRenderer>();

        Vector3 aMax = playerRenderer.bounds.max;
        Vector3 aMin = playerRenderer.bounds.min;
        Vector3 bMax = enemyRenderer.bounds.max;
        Vector3 bMin = enemyRenderer.bounds.min;

        if (bMin.x < aMax.x && bMax.x > aMin.x)
        {
            if (bMin.y > aMin.y && bMin.y < aMax.y)
            {
                return true;
            }
        }

        return false;
    }


}
