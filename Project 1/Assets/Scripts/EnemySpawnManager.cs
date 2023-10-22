using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawner;
    public float spawnInterval = 2.0f;
    public float currentTime = 0f;
    public CollisionManager collisionManager;

    private void Start()
    {
        collisionManager = GameObject.Find("Manager").GetComponent<CollisionManager>();
    }

    public void Update()
    {
        if(currentTime < spawnInterval)
        {
            currentTime += Time.deltaTime;
        } else if(currentTime >= spawnInterval)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = transform.position;
            collisionManager.EnemyList.Add(enemy);

            currentTime = 0f;
        }
    }
    
}
