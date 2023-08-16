using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]private inputController input = null;
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float maxAcceleration = 35f;
    [SerializeField, Range(0f, 600)] private float maxAirAcceleration = 20;

    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;
    private Rigidbody2D rb;
    private groundCheck groundCheck;

    private float maxSpeedChange;
    private float acceleration;
    private bool onGround;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<groundCheck>();
    }

    void Update(){
        direction.x = input.retrieveMoveInput();
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - groundCheck.getfriction(), 0f);
    }
    private void FixedUpdate(){
        onGround = groundCheck.getOnGround();

        velocity = rb.velocity;

        acceleration = onGround? maxAcceleration:maxAirAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        rb.velocity = velocity;

    }
}
