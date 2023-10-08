using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDragonAttack : MonoBehaviour
{
    public GameObject enemy;
    public GameObject attack;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Attack()
    {
        Instantiate(attack, new Vector3((float)(transform.position.x-2), transform.position.y,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 600 == 0 && transform.position.x == 3)
        {
            Attack();
        }
    }

    public GameObject healthBoss;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Fireball(Clone)")
        {
            int pos = healthBoss.transform.hierarchyCount - 2;
            Destroy(healthBoss.transform.GetChild(pos).gameObject);
            if (pos <= 0) SceneManager.LoadScene("Winner");
        }
    }
}
