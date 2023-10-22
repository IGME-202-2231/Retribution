using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5.0f; 
    public GameObject spawner;

    public Vector2 direction;
    public Vector2 velocity;
    public Vector2 position;

    public void Start()
    {
        position = transform.position;
    }

    private void Update()
    {
        // Establish the direction
        direction = Vector2.left;

        // Apply direction and speed to velocity
        velocity = direction * speed * Time.deltaTime;

        // Add velocity to position
        position = position + velocity;

        // Check positions

        // Set position to transform.position
        transform.position = position;
        position = transform.position;

        // Check if the enemy has moved off the screen
        if (transform.position.x < -10f) 
        {
            // Deactivate the enemy
            gameObject.SetActive(false);    // destroy instead
        }
    }
}

