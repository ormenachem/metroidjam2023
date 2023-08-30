using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gliding : MonoBehaviour
{
    [SerializeField] inputController input;
    [SerializeField] groundCheck groundCheck;

    
    [SerializeField] private float glidingForwardSpeed;
    [SerializeField] private float glidingDownwardsSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public bool isGliding;
    private bool isFacingRight = true;
    private float defultGravityScale;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponentInChildren<groundCheck>();
        defultGravityScale = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        glidingDownwardsSpeed += Input.GetAxisRaw("Vertical") * .5f;
        if (transform.localScale.x >0)isFacingRight = true;
        if (transform.localScale.x <0)isFacingRight = false;
        if(Input.GetButton("Glide") && !groundCheck.getOnGround()){
            isGliding = true;
            
            if(isFacingRight)
            rb.velocity = new Vector2(glidingForwardSpeed * Time.fixedDeltaTime, glidingDownwardsSpeed);
            else
            rb.velocity = new Vector2(-glidingForwardSpeed * Time.fixedDeltaTime, glidingDownwardsSpeed);

            
            
        }else{
            isGliding = false;
            
        }
    }
}
