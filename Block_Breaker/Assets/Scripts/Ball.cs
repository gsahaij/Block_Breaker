using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float speed = 200f;
    public Transform paddleTransform;
    private Rigidbody2D rigidBody;
    private Transform tf;
    private bool launched = false; // Boolean for if the ball is launched by hitting "Space"
    private Vector2 direction; // Direction of the ball
    public HudManager hud;
    private void Awake()
    {
        tf = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        hud.Refresh();
    }
    // Start is called before the first frame update
    private void Update()
    {
        if (!launched)
        {
            // Lock position to paddle when not launched
            Vector3 newPosition = new Vector3(paddleTransform.position.x, 0.0f);
            tf.localPosition = newPosition;

            if (Input.GetKey(KeyCode.Space)) // If you hit space then the ball is launche 
            {
                AddStartingForce();
                launched = true;
            }
        }

    }
    private void MoveWithPaddle() // Idea for getting the ball to move with the paddle at the start of the game
    {
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

    void OnBecameInvisible()
    {
        GameManager.instance.score = 0;
        hud.Refresh();
        SceneManager.LoadScene("SampleScene");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Block"))
        {
            GameManager.instance.IncreaseScore(1);
            hud.Refresh();
            Destroy(collision.gameObject);
        }
    }
}
