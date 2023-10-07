using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{

    public GameObject Projectile;

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 60 == 0)
        {
            int amount = 3;
            for (int i = 0; i < amount; i++)
            {
                Vector3 RandomSpawnPosition = new Vector3(12, Random.Range(-5, 5), 0);
                Instantiate(Projectile, RandomSpawnPosition, Quaternion.identity);
            }
        }
    }
}
