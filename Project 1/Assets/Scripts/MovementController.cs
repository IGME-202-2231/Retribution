using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Vector3 objectPosition = Vector3.zero;
    [SerializeField]

    float speed = 5.0f;
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;
    private Camera gameCamera;

    // Start is called before the first frame update
    void Start()
    {
        objectPosition = transform.position;
        gameCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;  // constant velocity despite fps

        objectPosition += velocity; // adds velocity vector to position

        transform.position = objectPosition;

    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;    

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }
}
