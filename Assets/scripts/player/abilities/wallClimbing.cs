using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class wallClimbing : MonoBehaviour

{

    [SerializeField]private float wallCheckHeight;
    [SerializeField]private float wallCheckLength;
    [SerializeField]private float facingLeftOffset;
    [SerializeField]private LayerMask wallLayer;
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField]private float onWallDrag;
    [SerializeField]private float wallClimbSpeed;
    [SerializeField]private inputController input;
    private bool isFacingRight = true;
    private bool onWall;
    private float defultDrag;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        defultDrag = rb.drag;
        
    }

        void Update(){
            
            animator.SetBool("isWallClimbing", onWall);
            
            if (transform.localScale.x >0)isFacingRight = true;
            if (transform.localScale.x <0)isFacingRight = false;
            if(onWall && rb.velocity.y<0){
                rb.drag = onWallDrag;
                if(input.retrieveJumpInput()){
                    rb.AddForce(Vector2.up * Time.fixedDeltaTime*wallClimbSpeed, ForceMode2D.Impulse);
                }
            }else GetComponent<Rigidbody2D>().drag = defultDrag;
            
    }
    void OnCollisionStay2D(Collision2D collision){
        onWall = wallCheck();
    }
    void OnCollisionExit2D(Collision2D collision) {
        onWall = false;
    }
    bool wallCheck(){
        if(isFacingRight){
            return Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y+wallCheckHeight), Vector2.right,wallCheckLength, wallLayer) || Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y), Vector2.right,wallCheckLength, wallLayer);
        }else{
            return Physics2D.Raycast(new Vector3(transform.position.x+facingLeftOffset, transform.position.y+wallCheckHeight), -Vector2.right,wallCheckLength, wallLayer) || Physics2D.Raycast(new Vector3(transform.position.x+facingLeftOffset, transform.position.y), -Vector2.right,wallCheckLength, wallLayer);
            
        }
    }
    void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        if(isFacingRight){
            Gizmos.DrawRay(new Vector3(transform.position.x, transform.position.y),wallCheckLength* Vector2.right);
            Gizmos.DrawRay(new Vector3(transform.position.x, transform.position.y+wallCheckHeight),wallCheckLength* Vector2.right);
        }else{
            Gizmos.DrawRay(new Vector3(transform.position.x+facingLeftOffset, transform.position.y+wallCheckHeight),wallCheckLength* -Vector2.right);
            Gizmos.DrawRay(new Vector3(transform.position.x+facingLeftOffset, transform.position.y),wallCheckLength* -Vector2.right);
        }
    }
}
