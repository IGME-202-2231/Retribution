using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPF;
    public CollisionManager collisionManager;

    [SerializeField]
    public float shootInterval = 0.05f;
    public float currentTime = 0f;

    private void Start()
    {
        collisionManager = GameObject.Find("Manager").GetComponent<CollisionManager>();
    }


    // Update is called once per frame
    void Update()
    {
        // bullet delay timer
        if (currentTime < shootInterval)
        {
            currentTime += Time.deltaTime;
        }
        else if (currentTime >= shootInterval) 
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Instantiate(bulletPF, shootingPoint.position, transform.rotation);
                collisionManager.Bullets.Add(bulletPF);
                currentTime = 0f;
            }
        }
        
    }
}
