using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D rigidBody; // Rigidbody2D reference for movement
    public float moveSpeed = 100f; // Speed at which the object moves
    

    void Awake(){
        rigidBody = GetComponent<Rigidbody2D>(); // Get the RigidBody info from prefab
       


    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void FixedUpdate(){
    
    }
}
