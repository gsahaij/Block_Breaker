using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D rigidBody; // Rigidbody2D reference for movement
    public float speed = 100f; // Speed at which the object moves
    private Vector2 direction;
    private bool launched = false;
    

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // Get the RigidBody info from prefab
    }

    // Update is called once per frame
    void Update()
    {
        if (launched)
        {
            Move();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            launched = true;
        }
        
        
    }
    void FixedUpdate()
    {
        if (direction.sqrMagnitude != 0)
        {
            rigidBody.AddForce(direction * this.speed);
        }

    }
    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        direction = new Vector2(horizontalInput, 0);
        rigidBody.AddForce(direction * this.speed);
    }
}
