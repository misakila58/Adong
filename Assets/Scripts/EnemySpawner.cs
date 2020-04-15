using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float timer = 0f;
    public float spawnDelay;

    public static bool shopTime = false;

    public GameObject enemy;

    public GameObject upgradePanel;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && !shopTime)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-2f, 2f), 6.5f);
            Instantiate(enemy, spawnPos, transform.rotation);
            timer = spawnDelay;
        }

        if (PlayerStats.UpgradeGage >= 10)
        {
            upgradePanel.SetActive(true);
        }
    }
}
