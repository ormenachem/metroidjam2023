using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class groundCheck : MonoBehaviour
{ 
    bool onGround;
    [SerializeField] LayerMask groundLayer;
    public float getFriction(){
        return 0;
    }
    public bool getOnGround(){
        return onGround;
    }
    void OnTriggerStay2D(Collider2D collision){
        //if is triggered by an object on the ground layer set onGround to true
        
        onGround = true;
        
    }
    void OnTriggerExit2D(Collider2D collision){
        /*
        when an object stops triggering this object, the onGround will be set to false
        
        no need to check for the layer here because if the player is still on the ground when this happens
        it will be fixed with the onTriggerStay2D method
        
        */
        onGround = false;
    }
}

