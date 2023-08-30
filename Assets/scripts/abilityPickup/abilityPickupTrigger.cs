using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Presets;
using UnityEngine;

public class abilityPickupTrigger : MonoBehaviour
{
    [SerializeField]private Ability abilityToTrigger;
    
    [SerializeField]private Preset wallClimbPreset;
    [SerializeField]private Preset doubleJumpPreset;
    [SerializeField]private Preset fireBreathingPreset;
    [SerializeField]private Preset glidingPreset;
    [SerializeField]private Preset groundPoundPreset;

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
                    if(player.GetComponent<gliding>() == null){
                        glidingPreset.ApplyTo(player.AddComponent<gliding>());
                    }
                    break;
                case Ability.groundPound:
                    break;
                case Ability.wallClimbing:
                    if(player.GetComponent<wallClimbing>() == null){
                        wallClimbPreset.ApplyTo(player.AddComponent<wallClimbing>());
                    }
                    break;
                case Ability.key:
                    break;
            }
        }
    }
}