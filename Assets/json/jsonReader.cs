using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Rendering;

public class jsonReader : MonoBehaviour
{
    [SerializeField]private TextAsset statsJSON;
    
    [System.Serializable]
    public class PlayerStats{
        public float currentHealth;
        public float maxHealth;
        public bool hasWallJump;

        public PlayerStats getFromJSON(TextAsset jsonFile){
            return JsonUtility.FromJson<PlayerStats>(jsonFile.text);
        }
        public void updateJSON(TextAsset jsonFile){
            string jsonForm = JsonUtility.ToJson(this, true);
            File.WriteAllText(AssetDatabase.GetAssetPath(jsonFile), jsonForm);  
        }
    }

}
