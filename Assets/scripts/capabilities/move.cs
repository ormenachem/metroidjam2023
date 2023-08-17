using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]private inputController input = null;
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 4f;
    [SerializeField, Range(0f, 600f)] private float maxAcceleration = 35f;
    [SerializeField, Range(0f, 600)] private float maxAirAcceleration = 20;

    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;
    private Rigidbody2D rb;
    private groundCheck groundCheck;

    private float maxSpeedChange;
    private float acceleration;
    private bool onGround;
    private bool hasLanded;
    private bool isFacingRight;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponentInChildren<groundCheck>();
    }

    void Update(){
        isFacing();

        if (isFacingRight == true && input.retrieveMoveInput() < 0f && input.retrieveMoveInput() > -1f) 
        {
            transform.Rotate(0f, -180f, 0f);
        }

        if (onGround && hasLanded == false) {
            hasLanded = true;
            rb.drag = 5f;
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, 0.3f), rb.velocity.y);
        }

        if (!onGround && hasLanded == true) {
            hasLanded = false;
        }

        while (onGround)
        {
            if (input.retrieveMoveInput() == 0f && rb.velocity.x != 0) 
            {
                rb.velocity = Vector2.MoveTowards(rb.velocity, new Vector2(0, rb.velocity.y), 0.15f);
            }
            break;
        }

        direction.x = input.retrieveMoveInput();
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - groundCheck.getFriction(), 0f);
    }
    private void FixedUpdate(){

        onGround = groundCheck.getOnGround();

        velocity = rb.velocity;

        acceleration = onGround? maxAcceleration:maxAirAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        rb.velocity = velocity;

    }

// A function for checking which way the player is looking at
    private void isFacing()
    {
        // If the player is walking the opposite way of which he is facing then he is considered !facingRight
        if (input.retrieveMoveInput() < 1f && input.retrieveMoveInput() > 0f)
        {
            isFacingRight = true;
        }

        else
        {
            isFacingRight = false;
        }
    }

// A function for rotating the player

    private void rotatePlayer()
    {
        
    }
}
