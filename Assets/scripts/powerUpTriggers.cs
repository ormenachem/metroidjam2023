using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Callbacks;
using UnityEngine;

public class powerUpTriggers : MonoBehaviour
{
    

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player")){
            Debug.Log("You triggered something!");
        }
        
    }
}
