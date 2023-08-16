using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Callbacks;
using UnityEngine;

public class powerUpTriggers : MonoBehaviour
{
    // Colliders for the triggers
    public Collider2D dJColl;

    private static statManager pStats;
    

    static void OnTriggerEnter2D(Collider2D dJColl) 
    {
        Debug.Log("You triggered something!");
        statManager.hasDoubleJumping = true;
    }
}
