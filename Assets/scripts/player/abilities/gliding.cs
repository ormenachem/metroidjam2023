using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gliding : MonoBehaviour
{
    // Some variables
    private groundCheck gc;
    
    private Rigidbody2D rb;

    void Start() 
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        while (gc.onGround == false) 
        {
            while (Input.GetButton("Jump")) 
            {
                rb.gravityScale = rb.gravityScale * 0.3f;
                break;
            }
            break;
        }
    }
}
