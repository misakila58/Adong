using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public DialougeManager dialougeManager;
    private float timer = 0f;
    public float spawnDelay;

    public static bool shopTime = false;

    public GameObject[] enemy;

    public GameObject upgradePanel;

    void Start()
    {

    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && !shopTime)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-2f, 2f), 6.5f);
            int enemyNum = Random.Range(1, 100);

            if (0 < enemyNum && enemyNum <= 60)
                Instantiate(enemy[0], spawnPos, transform.rotation);
            else if (60 < enemyNum && enemyNum <= 100)
                Instantiate(enemy[1], spawnPos, transform.rotation);

            timer = spawnDelay;
        }

        if (PlayerStats.UpgradeGage >= 10)
        {
            upgradePanel.SetActive(true);
        }
    }
}
