using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float spd;

    private EnemySpawner enemySpawner;

    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Update()
    {
        ShootType1();

        if (EnemySpawner.shopTime)
        {
            Destroy(gameObject);
        }
    }

    void ShootType1()
    {
        transform.Translate(Vector3.down * spd * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Crossbow")
        {
            PlayerStats.Hp--;
            Destroy(gameObject);
        }        
    }
}
