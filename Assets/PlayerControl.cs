using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private float YPos = 0;
    private bool gameoverCalled = false;
    public GameObject HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition();
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, YPos), Time.deltaTime*15);
        // Out of bound check lmao
        if (Math.Abs(transform.position.x) > 12 ||
            MathF.Abs(transform.position.y) > 8)
            gameOverHandler();
    }

    void PlayerPosition()
    {
        int SensorDistance = NetworkHandler.distance;
        // SensorDistance 5 or lower = Y=-4
        // SensorDistance 15 = Y=0
        // SensorDistance 25 or higher = Y=4
        if (SensorDistance <= 5) YPos = -4;
        else if (SensorDistance > 25) YPos = 4;
        else YPos = (float)(SensorDistance*0.4 - 6);
    }
    void gameOverHandler()
    {
        if (gameoverCalled) return;
        gameoverCalled = true;
        Debug.Log("GAME OVER HANDLER CALLED");
        SceneManager.LoadScene("GameOver");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Arrow(Clone)" ||
            collision.gameObject.name == "Boss Fireball(Clone)")
        {
            int ind = HealthBar.transform.hierarchyCount - 2;
            Destroy(HealthBar.transform.GetChild(ind).gameObject);
            if (ind == 0) gameOverHandler();
        }
    }
}
