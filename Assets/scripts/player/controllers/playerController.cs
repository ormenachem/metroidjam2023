using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="playerController", menuName ="inputController/playerController")]
public class playerController : inputController
{
    public override bool retrieveJumpInput(){
        return Input.GetButtonDown("Jump");
        
    }
    public override float retrieveMoveInput(){
        return Input.GetAxisRaw("Horizontal");

    }
}
