using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Change position one to the left
        transform.position = transform.position + new Vector3((float)-0.011, 0, 0);
        if (transform.position.x < -12) Destroy(gameObject);
    }
}
