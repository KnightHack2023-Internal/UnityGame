using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public GameObject player;
    public AudioSource audioclip;
    int frames = 0;
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
    bool freeze = false;
    int framePass = 0;
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

            if(!freeze)
                transform.position = new Vector3(3, player.transform.position.y, 0);
            if (freeze)
                if (++framePass >= 60 * 3)
                {
                    freeze = false;
                    framePass = 0;
                }
            if (Time.frameCount % 600 == 0) freeze = true;
            /*
            if (Time.frameCount % 600 == 0 || (Time.frameCount < frames + 180 && Time.frameCount >= frames))
            {
                frames = Time.frameCount;
                if (Time.frameCount > frames + 180)
                    {
                        Debug.Log("Fire!");
                        frames = 0;
                    }
            }*/
        }

    }
}
