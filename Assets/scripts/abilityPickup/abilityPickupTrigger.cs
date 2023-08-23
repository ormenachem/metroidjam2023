using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilityPickupTrigger : MonoBehaviour
{
    [SerializeField] private Abilities abilityToTrigger;
    [SerializeField] private jsonReader jsonReader;

    enum Abilities{
        doubleJump, wallClimbing, fireBreathing, groundPound, gliding 
    }
    // Start is called before the first frame update
    void Start()
    {
        jsonReader = GameObject.FindGameObjectWithTag("gameManager").GetComponent<jsonReader>();
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player")){
            jsonReader.PlayerStats newPlayerStatsObject = new jsonReader.PlayerStats();
            
            switch(abilityToTrigger)
            {
                case Abilities.doubleJump:
                    newPlayerStatsObject = newPlayerStatsObject.getFromJSON(jsonReader.statsJSON);
                    newPlayerStatsObject.hasDoubleJump = true;
                    break;
                case Abilities.wallClimbing:
                    newPlayerStatsObject = newPlayerStatsObject.getFromJSON(jsonReader.statsJSON);
                    newPlayerStatsObject.hasWallClimb = true;
                    break;
                case Abilities.fireBreathing:
                    newPlayerStatsObject = newPlayerStatsObject.getFromJSON(jsonReader.statsJSON);
                    newPlayerStatsObject.hasFireBreathing = true;
                    break;
                case Abilities.groundPound:
                    newPlayerStatsObject = newPlayerStatsObject.getFromJSON(jsonReader.statsJSON);
                    newPlayerStatsObject.hasGroundPound = true;
                    break;
                case Abilities.gliding:
                    newPlayerStatsObject = newPlayerStatsObject.getFromJSON(jsonReader.statsJSON);
                    newPlayerStatsObject.hasGliding = true;
                    break;
            }
            newPlayerStatsObject.updateJSON(jsonReader.statsJSON);
        }
    }
}
