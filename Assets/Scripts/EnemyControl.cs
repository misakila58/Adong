using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{
    public int type;// 0:normal  1:tank  2:range
    public float spd;
    public float hp;
    public float startHp;

    public float firstShotDelay;
    public float reloadTimer;
    private float timer;

    public GameObject bullet;
    public Transform shootPosition;

    public Image hpBar;

    private EnemySpawner enemySpawner;
    private ActivePerks activePerks;

    // Start is called before the first frame update
    void Start()
    {
        hp = startHp;
        timer = firstShotDelay;

        enemySpawner = GameObject.FindGameObjectWithTag("enemySpawner").GetComponent<EnemySpawner>();
        activePerks = GameObject.FindGameObjectWithTag("Crossbow").GetComponent<ActivePerks>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * spd * Time.deltaTime);

        if (type == 2)
            Shoot();

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

    public void TakeDamage(int damage)
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

    void Shoot()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(bullet, shootPosition.transform.position, transform.rotation);
            timer = reloadTimer;
        }
    }
}
