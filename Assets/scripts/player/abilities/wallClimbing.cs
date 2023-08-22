using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallClimbing : MonoBehaviour
{
    [SerializeField]private bool hasWallJump;
    [SerializeField]private float wallCheckHeight;
    [SerializeField]private float wallCheckLength;
    [SerializeField]private float facingLeftOffset;
    [SerializeField]private LayerMask wallLayer;
    [SerializeField]private Rigidbody2D rb;
    private bool isFacingRight = true;
    private bool onWall;
    // Start is called before the first frame update
    void Start()
    {
        hasWallJump = jsonReader.playerStats.hasWallJump;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        onWall = wallCheck();
        if (transform.localScale.x >0)isFacingRight = true;
        if (transform.localScale.x <0)isFacingRight = false;
    }
    bool wallCheck(){
        if(isFacingRight){
            return Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y+wallCheckHeight), Vector2.right,wallCheckLength, wallLayer);
        }else{
            return Physics2D.Raycast(new Vector3(transform.position.x+facingLeftOffset, transform.position.y+wallCheckHeight), -Vector2.right,wallCheckLength, wallLayer);
        }
    }
    void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        if(isFacingRight){
            Gizmos.DrawRay(new Vector3(transform.position.x, transform.position.y+wallCheckHeight),wallCheckLength* Vector2.right);
        }else{
            Gizmos.DrawRay(new Vector3(transform.position.x+facingLeftOffset, transform.position.y+wallCheckHeight),wallCheckLength* -Vector2.right);
        }
    }
}
