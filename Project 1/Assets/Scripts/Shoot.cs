using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPF;

    [SerializeField]
    public float shootInterval = 0.05f;
    public float currentTime = 0f;

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
                currentTime = 0f;
            }
        }
        
    }
}
