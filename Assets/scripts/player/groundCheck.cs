using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    private bool onGround;
    private float friction;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision){
        evaluateCollision(collision);
        RetrieveFriction(collision);
    }
    private void OnCollisionStay2D(Collision2D collision){
        evaluateCollision(collision);
        RetrieveFriction(collision);
    }
    private void OnCollisionExit2D(Collision2D collision){
        onGround = false;
        friction = 0;
    }
    private void evaluateCollision(Collision2D collision){
        for(int i = 0; i <collision.contactCount; i++){
            Vector2 normal = collision.GetContact(i).normal;
            onGround |= normal.y >= 0.9f;
        }
    }
    private void RetrieveFriction(Collision2D collision){
        PhysicsMaterial2D material = collision.rigidbody.sharedMaterial;
        friction = 0;
        if(material != null){
            friction = material.friction;
        }
    }
    public bool getOnGround(){
        return onGround;
    }
    public float getfriction(){
        return friction;
    }
}
