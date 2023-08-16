using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class inputController : ScriptableObject
{
    public abstract float retrieveMoveInput();
        
    
    public abstract bool retrieveJumpInput();

    
}
