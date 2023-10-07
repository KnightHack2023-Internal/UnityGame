using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public GameObject player;
    public AudioSource audioclip;
    bool loc = false;
    // Start is called before the first frame update

    private IEnumerator FightDelay()
    {
        yield return new WaitForSeconds(3);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Change position one to the left
        if (transform.position.x > 3) transform.position = transform.position + new Vector3((float)-0.005, 0, 0);
        else
        {
            if(!loc)
            {
                audioclip.Play();
                loc = true;
            }
            Debug.Log("Fight start!");
            StartCoroutine(FightDelay());
            transform.position = new Vector3(3, player.transform.position.y, 0);
        }

    }
}
