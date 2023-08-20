using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class jsonReader : MonoBehaviour
{
    [SerializeField]private TextAsset statsJSON;
    public PlayerStats playerStats;

    void Awake(){
        playerStats = JsonUtility.FromJson<PlayerStats>(statsJSON.text);
    }
    [System.Serializable]
    public class PlayerStats{
        public float currentHealth;
        public float maxHealth;
        public bool hasDoubleJump;
    }

}
