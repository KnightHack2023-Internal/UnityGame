using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Change position one to the left
        if (transform.position.x > 0) transform.position = transform.position + new Vector3((float)-0.005, 0, 0);

    }
}
