using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MovementType
{
    straight,
    updown,
}

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5.0f; 

    public Vector2 direction;
    public Vector2 velocity;
    public Vector2 position;

    [SerializeField]
    MovementType enemyMovementStyle;

    float timer;

    public void Start()
    {
        position = transform.position;
        timer = 0;
    }

    private void Update()
    {
        // Establish the direction
        direction = Vector2.left;

        // Apply direction and speed to velocity
        velocity = direction * speed * Time.deltaTime;

        // Add velocity to position
        position = position + velocity;


        timer += Time.deltaTime;
        // Check positions
        position.y = Mathf.Sin(timer) * 4;

        // Set position to transform.position
        transform.position = position;
        position = transform.position;

        // Check if the enemy has moved off the screen
        if (transform.position.x < -10f) 
        {
            FindObjectOfType<CollisionManager>().EnemyList.Remove(gameObject);
            // Deactivate the enemy
            Destroy(gameObject);
            //gameObject.SetActive(false);    // destroy instead
        }
    }
}

