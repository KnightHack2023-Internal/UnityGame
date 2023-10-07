using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballSpawn : MonoBehaviour
{

    public GameObject Projectile;

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 60 == 0)
        {
            Vector3 RandomSpawnPosition = new Vector3(Random.Range(1,5), -6, 0);
            Instantiate(Projectile, RandomSpawnPosition, Quaternion.identity);
        }
    }
}
