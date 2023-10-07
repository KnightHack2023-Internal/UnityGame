using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Application.targetFrameRate = 60;
        rb.velocity = new Vector2(0, Random.Range(5,20));
    }

    // Update is called once per frame
    void Update()
    {
        // Change position one to the left
        transform.position = transform.position + new Vector3((float)-0.09, 0, 0);
        if (transform.position.y < -7) Destroy(this.gameObject);
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision Detected!");
            Destroy(this.gameObject);
        }

    }
}
