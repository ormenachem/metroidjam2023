using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Callbacks;
using UnityEngine;

public class powerUpTriggers : MonoBehaviour
{
    private statManager pStats;

    void Start()
    {
        pStats = GameObject.Find("gameManager").GetComponent<statManager>();
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player")){
            pStats.hasDoubleJumping = true;
        }
        
    }
}
