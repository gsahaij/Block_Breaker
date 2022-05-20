using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D rigidBody; // Rigidbody2D reference for movement
    public float speed = 100f; // Speed at which the object moves
    private Vector2 direction;
    private bool launched = false;
    

    void Awake(){
        rigidBody = GetComponent<Rigidbody2D>(); // Get the RigidBody info from prefab
       


    }

    // Update is called once per frame
    void Update()
    {
        if (launched){
        move();
        }

        if (Input.GetKey(KeyCode.Space)){
            launched = true;
        }
        
        
    }
    void FixedUpdate(){
        if (direction.sqrMagnitude != 0)
        {
            rigidBody.AddForce(direction * this.speed);
        }

    }
    void move()
    {
        float x = 0;
        if (Input.GetKey(KeyCode.A))
        {
            x = -0.5f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x = 0.5f;
        }
        direction = new Vector2(x, 0);
        rigidBody.AddForce(direction * this.speed);
    }
}
