using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float timer = 0f;
    public float spawnDelay;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-2f, 2f), 6.5f);
            Instantiate(enemy, spawnPos, transform.rotation);
            timer = spawnDelay;
        }
    }
}
