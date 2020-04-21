using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{
    public float spd;
    public float hp;
    public float startHp;

    public Image hpBar;

    private EnemySpawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        hp = startHp;

        enemySpawner = GameObject.FindGameObjectWithTag("enemySpawner").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
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
            Destroy(col.gameObject);
            TakeDamage(PlayerStats.Dmg);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        hpBar.gameObject.SetActive(true);
        hpBar.fillAmount = hp / startHp;

        if (hp <= 0)
        {
            PlayerStats.UpgradeGage++;
            Destroy(gameObject);
        }
    }
}
