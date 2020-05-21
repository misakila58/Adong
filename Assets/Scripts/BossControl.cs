using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossControl : MonoBehaviour
{
    public float spd;
    public float hp;
    public float startHp;

    public GameObject bullet;
    public Transform shootPosition;

    public Image hpBar;

    private EnemySpawner enemySpawner;
    private ActivePerks activePerks;

    // Start is called before the first frame update
    void Start()
    {
        hp = startHp;

        enemySpawner = GameObject.FindGameObjectWithTag("enemySpawner").GetComponent<EnemySpawner>();
        activePerks = GameObject.FindGameObjectWithTag("Crossbow").GetComponent<ActivePerks>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemySpawner.shopTime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Bullet")
        {
            Destroy(col.gameObject);
            TakeDamage(PlayerStats.Dmg);
        }

        if (col.transform.tag == "Trap")
        {
            Destroy(col.gameObject);
            TakeDamage(activePerks.trapDmg);
        }

        if (col.transform.tag == "Laser")
        {
            TakeDamage(activePerks.laserDmg);
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        hpBar.gameObject.SetActive(true);
        hpBar.fillAmount = hp / startHp;

        if (hp <= 0)
        {
            enemySpawner.curKills++;
            Destroy(gameObject);
        }
    }

}
