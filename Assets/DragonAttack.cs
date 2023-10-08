using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAttack : MonoBehaviour
{
    public GameObject enemy;
    public GameObject attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Attack()
    {
        Instantiate(attack, new Vector3((float)(transform.position.x+2.5), transform.position.y,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 180 == 0 && enemy.transform.position.x == 3)
        {
            Attack();
        }
    }
}
