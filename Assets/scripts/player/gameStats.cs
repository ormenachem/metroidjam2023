using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Presets;
using UnityEngine.SceneManagement;
public class gameStats : MonoBehaviour
{
    public static float maxHealth;
    public static float currentHealth;
    
    public static bool hasWallClimbing;
    public static bool hasGliding;
    [SerializeField]private Preset wallClimbPreset;
    [SerializeField]private Preset doubleJumpPreset;
    [SerializeField]private Preset fireBreathingPreset;
    [SerializeField]private Preset glidingPreset;
    [SerializeField]private Preset groundPoundPreset;
    void Awake(){
        checkAbilities();
    }
    void Update(){
        if(Input.GetKeyDown("g")){
            SceneManager.LoadScene("1-1");
        }
    }
    public void checkAbilities(){
        var player = GameObject.FindWithTag("Player");
        if(hasWallClimbing && player.GetComponent<wallClimbing>() == null){
            wallClimbPreset.ApplyTo(player.AddComponent<wallClimbing>());
        }
        if(hasWallClimbing && player.GetComponent<gliding>() == null){
            glidingPreset.ApplyTo(player.AddComponent<gliding>());
        }
    }
}
