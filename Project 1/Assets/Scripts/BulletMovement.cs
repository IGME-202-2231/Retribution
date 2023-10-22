using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bulletSpawner;

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
        direction = transform.position.normalized;

        // Apply direction and speed to velocity
        velocity = direction * speed * Time.deltaTime;

        // Add velocity to position
        position = position + velocity;

        // Set position to transform.position
        transform.position = position;
        position = transform.position;

        // Check if the enemy has moved off the screen
        if (transform.position.x < -10f)
        {
            // Deactivate the bullet
            gameObject.SetActive(false);    // destroy instead
        }
    }

}
