using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public DialougeManager dialougeManager;
    private float timer = 0f;

    public static bool shopTime = false;

    public GameObject[] enemy;

    public GameObject upgradePanel;

    public float curKills;
    public float remainKills;
    public static float spawnDelay;
    public static int spawnType;

    public int startRemainKills;
    public int startSpawnDelay;
    public int remainKillsAddAmount;
    public float spawnDelayReduceAmount;

    void Start()
    {
        curKills = 0;
        remainKills = startRemainKills;
        spawnType = 1;
        spawnDelay = startSpawnDelay;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && !shopTime)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-2f, 2f), 6.5f);
            int enemyNum = Random.Range(1, 100);

            if (spawnType == 1)
            {
                if (0 < enemyNum && enemyNum <= 100)
                    Instantiate(enemy[0], spawnPos, transform.rotation);
            }
            else if (spawnType == 2)
            {
                if (0 < enemyNum && enemyNum <= 80)
                    Instantiate(enemy[0], spawnPos, transform.rotation);
                else if (80 < enemyNum && enemyNum <= 100)
                    Instantiate(enemy[1], spawnPos, transform.rotation);                
            }
            else if (spawnType == 3)
            {
                if (0 < enemyNum && enemyNum <= 80)
                    Instantiate(enemy[0], spawnPos, transform.rotation);
                else if (80 < enemyNum && enemyNum <= 90)
                    Instantiate(enemy[1], spawnPos, transform.rotation);
                else if (90 < enemyNum && enemyNum <= 100)
                    Instantiate(enemy[2], spawnPos, transform.rotation);
            }
            else if (spawnType == 4)
            {
                if (0 < enemyNum && enemyNum <= 70)
                    Instantiate(enemy[0], spawnPos, transform.rotation);
                else if (70 < enemyNum && enemyNum <= 85)
                    Instantiate(enemy[1], spawnPos, transform.rotation);
                else if (85 < enemyNum && enemyNum <= 100)
                    Instantiate(enemy[2], spawnPos, transform.rotation);
            }

            timer = spawnDelay;
        }

        if (curKills >= remainKills)
        {
            upgradePanel.SetActive(true);
        }
    }
}
