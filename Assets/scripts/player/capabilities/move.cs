using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]private inputController input = null;
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float maxAirSpeed = 4f;
    [SerializeField, Range(0f, 600f)] private float maxAcceleration = 35f;
    [SerializeField, Range(0f, 600)] private float maxAirAcceleration = 20;

    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;
    private Rigidbody2D rb;
    private groundCheck groundCheck;
    private Animator animator;

    private float maxSpeedChange;
    private float acceleration;
    private bool onGround;
    private bool hasLanded;
    private bool isFacingRight;

    void Awake(){
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponentInChildren<groundCheck>();
    }

    void Update(){

        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        animator.SetBool("isJumping", !groundCheck.getOnGround());
        direction.x = input.retrieveMoveInput();
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - groundCheck.getFriction(), 0f);
    }
    private void FixedUpdate(){
        rotatePlayer();
        onGround = groundCheck.getOnGround();

        velocity = rb.velocity;

        acceleration = onGround? maxAcceleration:maxAirAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        if(!onGround){
            if(GetComponent<gliding>() != null){
                if(!GetComponent<gliding>().isGliding)
                velocity.x = Mathf.Clamp(velocity.x, -maxAirSpeed, maxAirSpeed);
            }else{
                velocity.x = Mathf.Clamp(velocity.x, -maxAirSpeed, maxAirSpeed);
            }
        }
        rb.velocity = velocity;

    }
    void rotatePlayer(){
        if(velocity.x <0){
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        if(velocity.x >0){
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }



}
