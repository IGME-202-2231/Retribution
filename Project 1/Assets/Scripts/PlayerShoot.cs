using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    public GameObject BulletPrefab;
    public Transform BulletSpawnPoint;
    

    private void Start()
    {
        //movementController = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(BulletPrefab, BulletSpawnPoint.position, transform.rotation);
        }

        //bulletDirection = movementController.Direction;

        //// Add velocity to position
        //position = position + velocity;

        //// Set position to transform.position
        //transform.position = position;
        //position = transform.position;

        //// Check if the enemy has moved off the screen
        //if (transform.position.x < -10f)
        //{
        //    // Deactivate the bullet
        //    gameObject.SetActive(false);    // destroy instead
        //}
    }

    //public Vector2 BulletVelocity(Vector2 velocity)
    //{
    //    // Apply direction and speed to velocity
    //    velocity = bulletDirection * speed * Time.deltaTime;
    //    velocity = velocity.normalized;
    //    return velocity;
    //}
}
