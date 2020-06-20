﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
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
    public Image hpBarBack;

    private EnemySpawner enemySpawner;
    private ActivePerks activePerks;

    public Animator anim;
    public Collider2D col;

    void Start()
    {
        enemySpawner = GameObject.FindGameObjectWithTag("enemySpawner").GetComponent<EnemySpawner>();
        activePerks = GameObject.FindGameObjectWithTag("Crossbow").GetComponent<ActivePerks>();

        saveHp = startHp + (startHp * enemySpawner.curStage * 0.15f);
        hp = saveHp;
        timer = firstShotDelay;
        spd = startSpd;
    }

    void Update()
    {
        transform.Translate(Vector3.down * spd * Time.deltaTime);

        if (transform.position.y < -5.0f)
            Destroy(gameObject);

        if (type == 2)
            Shoot();

        if (EnemySpawner.shopTime)
        {
            anim.SetTrigger("Die");
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
            {
                if (ActivePerks.Pene)
                {
                    var b = col.GetComponent<Bullet>();
                    if (b.peneCount == 2)
                        TakeDamage(PlayerStats.Dmg * 0.5f);
                    else
                        TakeDamage(PlayerStats.Dmg);
                }
                else
                {
                    TakeDamage(PlayerStats.Dmg);
                }
            }                

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
        if(col.transform.tag == "purpleBottle") //보스가 던진 약병 
        {
                   
            hp = saveHp;
            spd = spd * 1.3f;
            TakeDamage(0); // HP바 업데이트를 위한 적용
            Destroy(col.gameObject);
        }

        if(col.transform.tag == "Explosion")
        {
            TakeDamage(20.0f);
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

        AudioManager.instance.Play("hit");
        hpBar.gameObject.SetActive(true);
        hpBarBack.gameObject.SetActive(true);
        hpBar.fillAmount = hp / saveHp;

        if (hp <= 0) //보스가 죽었을 시 
        {
            hpBar.gameObject.SetActive(false);
            hpBarBack.gameObject.SetActive(false);
            if (enemySpawner.curStage != 2)
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
