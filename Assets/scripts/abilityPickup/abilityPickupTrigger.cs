using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Presets;
using UnityEngine;

public class abilityPickupTrigger : MonoBehaviour
{
    [SerializeField]private Ability abilityToTrigger;
    
    

    [SerializeField]private GameObject player;
    enum Ability{
        groundPound, wallClimbing, fireBreathing, gliding, doubleJumping, key
    }
    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D colilsion){
        if(colilsion.CompareTag("Player")){
            switch(abilityToTrigger){
                case Ability.doubleJumping:
                    break;
                case Ability.fireBreathing:
                    break;
                case Ability.gliding:
                    gameStats.hasGliding = true;
                    break;
                case Ability.groundPound:
                    break;
                case Ability.wallClimbing:
                    gameStats.hasWallClimbing = true;
                    break;
                case Ability.key:
                    break;
            }
            GameObject.FindWithTag("gameManager").GetComponent<gameStats>().checkAbilities();
        }
    }
}