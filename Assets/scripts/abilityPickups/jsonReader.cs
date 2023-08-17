using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class jsonReader : MonoBehaviour
{
    [SerializeField]private TextAsset statJson;
    public playersStats playerStats;

    [System.Serializable]
    public class PlayerStats{
        public int health;
        public bool hasDoubleJump;
    }
    [System.Serializable]public class playersStats{
        public PlayerStats[] playerStats;
    }
    void Awake(){
        playerStats = JsonUtility.FromJson<playersStats>(statJson.text);
    }

}
