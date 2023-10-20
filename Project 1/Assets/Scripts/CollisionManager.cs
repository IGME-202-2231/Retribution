using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameObject Player;   //reference to player
    public List<GameObject> EnemyList;      

    // Update is called once per frame
    void Update()
    {
        bool isColliding = false;

        foreach (GameObject enemy in EnemyList)
        {
            if (Collisions(Player, enemy))  // collision detected
            {
                isColliding = true;
                enemy.GetComponent<SpriteRenderer>().color = Color.red;
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
    }

    bool Collisions(GameObject player, GameObject enemies)
    {
        Vector3 minA = player.transform.position - player.transform.localScale / 2f;
        Vector3 maxA = player.transform.position + player.transform.localScale / 2f;
        Vector3 minB = enemies.transform.position - enemies.transform.localScale / 2f;
        Vector3 maxB = enemies.transform.position + enemies.transform.localScale / 2f;

        if (maxA.x < minB.x || minA.x > maxB.x)
        {
            return false;
        }
        if (maxA.y < minB.y || minA.y > maxB.y)
        {
            return false;
        }
        return true;
    }
}
