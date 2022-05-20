using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 200f;
    private Rigidbody2D rigidBody;
    private bool launched = false; // Boolean for if the ball is launched by hitting "Space"
    private Vector2 direction; // Direction of the ball
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        
    }
    // Start is called before the first frame update
    private void Update(){
        if (!launched)
        {
            if (Input.GetKey(KeyCode.Space)) // If you hit space then the ball is launche 
            {
                AddStartingForce();
                launched = true;
            }
        }

    }
    private void MoveWithPaddle(){ // Idea for getting the ball to move with the paddle at the start of the game
        float horizontalInput = Input.GetAxis("Horizontal");
        direction = new Vector2(horizontalInput, 0);
        rigidBody.AddForce(direction * this.speed);
        
    }
    private void AddStartingForce()
    {
        
        float randomVal = Random.value; // Compute random val
        float x,y;
        if(randomVal > 0.5f) // 50/50 of going left or right
        {
            x = 1.0f;
            y = 1.0f;
        }
        else
        {
            x = -1.0f;
            y = 1.0f;
        }
        direction = new Vector2(x,y);
        rigidBody.AddForce(direction * this.speed); // Add force to the rigidbody when direction is decided

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
        }
    }
}
