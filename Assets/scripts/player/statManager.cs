using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class statManager : MonoBehaviour
{
    // public static float health;
    // public static float maxHealth;

    // public static bool hasWallClibing;
    // public static bool hasGliding;
    public bool hasDoubleJumping;
    // public static bool hasFireBreathing;

    // Scripts
    private jump pJump;

    void Start()
    {
        pJump = GameObject.Find("player"). GetComponent<jump>();
    }

    void update()
    {
        if (hasDoubleJumping == true)
        {
            pJump.maxAirJumps = 1;
        }

        else
        {
            pJump.maxAirJumps = 0;
        }
    }
}
