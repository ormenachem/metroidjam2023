using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail : MonoBehaviour
{
    [SerializeField] private TrailRenderer tr;
    // Start is called before the first frame update
    void Awake()
    {
        tr = transform.parent.GetChild(1).GetComponent<TrailRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tr.positionCount > 0)
        {
            // Get all positions of the points in the trail
            Vector3[] positions = new Vector3[tr.positionCount];
            tr.GetPositions(positions);
            
            // The last position in the array will be the position of the end of the trail
            Vector3 endPosition = positions[positions.Length - 1];
            
            // Use endPosition for whatever you need
            transform.position = endPosition;
        }
    }
}
