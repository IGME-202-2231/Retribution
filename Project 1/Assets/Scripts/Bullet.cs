using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject bullet;

    [SerializeField]
    Vector3 velocity;
    Vector3 position = Vector3.zero;

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = transform.right * speed * Time.deltaTime;

        position += velocity;

        transform.position = position;
    }

    // can't shoot bullet every frame
    void BulletDelay(float delay)
    {

    }
}
