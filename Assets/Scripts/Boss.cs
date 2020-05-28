using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int type;// 0:normal  1:tank  2:range
    private float spd;
    public float startSpd;
    public float hp;
    public float startHp;
    private float saveHp;

    public float firstShotDelay;
    public float reloadTimer;
    private float timer;

    public float score;

    public GameObject bullet;
    public Transform shootPosition;

    public Image hpBar;

    private EnemySpawner enemySpawner;
    private ActivePerks activePerks;

    public Animator anim;
    public Collider2D col;

    void Start()
    {
        enemySpawner = GameObject.FindGameObjectWithTag("enemySpawner").GetComponent<EnemySpawner>();
        activePerks = GameObject.FindGameObjectWithTag("Crossbow").GetComponent<ActivePerks>();

        saveHp = 100;
        hp = saveHp;
        timer = firstShotDelay;
        spd = startSpd;
    }

    void Update()
    {
        transform.Translate(Vector3.down * spd * Time.deltaTime);

        if (EnemySpawner.shopTime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Bullet")
        {
            if (!ActivePerks.Pene)
                Destroy(col.gameObject);

            if (ActivePerks.Vayne && ActivePerks.shootCount >= 3)
            {
                TakeDamage(PlayerStats.Dmg * 1.5f);
                ActivePerks.shootCount = 0;
            }
            else
                TakeDamage(PlayerStats.Dmg);

            if (ActivePerks.Slow)
                StartCoroutine(Slow());
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

        if (col.transform.tag == "Pass")
        {
            PlayerStats.Hp--;
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        float c = Random.Range(0f, 100f);

        if (c <= PlayerStats.CriChan)
        {
            hp -= damage * PlayerStats.CriDmg;
        }
        else
        {
            hp -= damage;
        }

        hpBar.gameObject.SetActive(true);
        hpBar.fillAmount = hp / saveHp;

        if (hp <= 0)
        {
            enemySpawner.curKills++;
            PlayerStats.Score += score;
            col.enabled = false;
            anim.SetTrigger("Die");
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

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    IEnumerator Slow()
    {
        spd = startSpd * 0.2f;
        yield return new WaitForSeconds(2f);
        spd = startSpd;
    }
}
