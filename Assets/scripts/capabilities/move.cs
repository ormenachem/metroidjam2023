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
        isFacingRight = true;
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponentInChildren<groundCheck>();
    }

    void Update(){
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
        isFacing();
        rotatePlayer();

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
        // Check for horizontal and then if the player is trying to walk to a direction he will be rotated to that direction
        if (input.retrieveMoveInput() < 0f && input.retrieveMoveInput() > -1f)
        {
            isFacingRight = false;
        }

        else if (input.retrieveMoveInput() > 0f && input.retrieveMoveInput() < 1f)
        {
            isFacingRight = true;
        }
    }

// A function for rotating the player

    private void rotatePlayer()
    {
        // If the player is facing one way and moving the other rotate the player to always look the way he's going
        if (isFacingRight == false && input.retrieveMoveInput() > 0f && input.retrieveMoveInput() < 1f)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
        }

        if (isFacingRight == true && input.retrieveMoveInput() < 0f && input.retrieveMoveInput() < -1f)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
        }
    }
}
