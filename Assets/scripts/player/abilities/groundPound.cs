using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundPound : MonoBehaviour
{
    [SerializeField]private float diveSpeed;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private groundCheck groundCheck;
    public bool isDiving;
    void Update(){
        if(Input.GetButtonDown("GroundPound")){
            isDiving = true;
        }
        if(isDiving){
            rb.velocity = new Vector2(0, -diveSpeed * Time.fixedDeltaTime);
            if(groundCheck.getOnGround()){
                isDiving = false;
            }
        }
    }
}
