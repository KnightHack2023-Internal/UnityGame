using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //1280 standard
        if(!Application.isEditor)
            Screen.SetResolution(1800, 850, false);
    }

    // Update is called once per frame
    void Update()
    {
        if(NetworkHandler.distance > 1000)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
