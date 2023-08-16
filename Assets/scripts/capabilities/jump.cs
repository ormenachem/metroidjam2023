using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class jump : MonoBehaviour
{
    [SerializeField] private inputController input = null;
    [SerializeField, Range(0f, 10f)] private float jumpHeight = 3f;
    [SerializeField] private int maxAirJumps = 0;
    [SerializeField, Range(0f, 5f)] private float downwardMovementMultiplier = 3f;
    [SerializeField, Range(0f, 5f)] private float upwardMovementMultiplier = 3f;

    private Rigidbody2D rb;
    private groundCheck groundCheck;
    private Vector2 velocity;

    private int jumpPhase;
    private float defultGravityScale;

    private bool desiredJump;
    private bool onGround;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<groundCheck>();

        defultGravityScale = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        desiredJump |= input.retrieveJumpInput();
        
    }
    void FixedUpdate(){
        onGround = groundCheck.getOnGround();
        velocity = rb.velocity;

        if(onGround){
            jumpPhase = 0;
        }
        if(desiredJump){
            desiredJump = false;
            jumpAction();
        }
        if(rb.velocity.y > 0){
            rb.gravityScale = upwardMovementMultiplier;
        }else if(rb.velocity.y <0){
            rb.gravityScale = downwardMovementMultiplier;
        }else{
            rb.gravityScale = defultGravityScale;
        }
        rb.velocity = velocity;
    }
    void jumpAction(){
        if(onGround || jumpPhase<maxAirJumps){
            jumpPhase++;
            float jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight);
            if(velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            }
            velocity.y +=jumpSpeed;
        }
    }
}
