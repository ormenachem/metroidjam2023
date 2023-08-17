using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class groundCheck : MonoBehaviour
{
    private bool onGround;
    private float friction = 0;

    [SerializeField] private float groundCheckHeight;
    [SerializeField] private Vector2 groundCheckSize; 

    void OnCollisionStay2D(Collision2D collision){
        RaycastHit2D hit = Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y+groundCheckHeight), groundCheckSize,0, Vector2.zero);
        onGround = (hit.transform != null);
    }
    void OnCollisionExit2D(Collision2D collision){
        onGround = false;
    }

    public float getFriction(){
        return friction;
    }
    public bool getOnGround(){
        return onGround;
    }
    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x, transform.position.y+groundCheckHeight), groundCheckSize);
    }
}
