using System.Collections;
using System.Collections.Generic;

using System.IO;
using UnityEngine;


public class jsonReader : MonoBehaviour
{
    public TextAsset statsJSON;

    public PlayerStats playerStats;
    
    void Awake(){
        playerStats = new PlayerStats();
        playerStats = playerStats.getFromJSON(statsJSON);
    }
    [System.Serializable]
    public class PlayerStats{
        public float currentHealth;
        public float maxHealth;
        public bool hasWallClimb;
        public bool hasDoubleJump;
        public bool hasGliding;
        public bool hasFireBreathing;
        public bool hasGroundPound;

        public PlayerStats getFromJSON(TextAsset jsonFile){
            return JsonUtility.FromJson<PlayerStats>(jsonFile.text);
        }
        // public void updateJSON(TextAsset jsonFile){
        //     string jsonForm = JsonUtility.ToJson(this, true);
        //     File.WriteAllText(AssetDatabase.GetAssetPath(jsonFile), jsonForm);  
        // }
        public void updateJSON(TextAsset jsonFile){
            string jsonForm = JsonUtility.ToJson(this, true);
            string path = Path.Combine(Application.persistentDataPath, jsonFile.name + ".json");
            File.WriteAllText(path, jsonForm);  
        }

    }

}
