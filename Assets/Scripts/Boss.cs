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

    private float bossPattenTime;

    public float firstShotDelay;
    public float reloadTimer;
    private float timer;

    public float score;

    public GameObject bullet;
    public Transform shootPosition;

    public Image hpBar;

    public GameObject redBottle;
    public GameObject greenBottle;
    public GameObject purpleBottle;


    private EnemySpawner enemySpawner;
    private ActivePerks activePerks;
    private DialougeManager dialougeManager;

    public Animator anim;
    public Collider2D col;

    void Start()
    {
        enemySpawner = GameObject.FindGameObjectWithTag("enemySpawner").GetComponent<EnemySpawner>();
        activePerks = GameObject.FindGameObjectWithTag("Crossbow").GetComponent<ActivePerks>();
        dialougeManager = GameObject.Find("GameManager").GetComponent<DialougeManager>();

        bossPattenTime = 3;
        saveHp = 100;
        hp = saveHp;
        timer = firstShotDelay;
        spd = startSpd;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        transform.Translate(Vector3.down * spd * Time.deltaTime);

        if (timer < 0)
        {
            Debug.Log("보스 패턴 들어감");
            
            int patten = Random.Range(1, 1);
            switch (patten) // 1 ~ 5까지는 1페이즈 2페이즈부터는 6 ~ 10 
            {
                case 1:
                    BossInitMonster();
                    timer = bossPattenTime;
                    break;
                default:
                    break;
            }

               


           
        }


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
            dialougeManager.textNum = 12; // 보스전 승리 
            PlayerStats.Score += score;
            col.enabled = false;
            anim.SetTrigger("Die");
        }
    }


    void BossPatten()
    {

    }

    void BossInitMonster() //보스 패턴 1 몬스터 생성 
    {
        //애니메이션 세팅 
        enemySpawner.timer = 0;
        enemySpawner.InitMonster(new Vector2(shootPosition.transform.position.x - 1.5f, shootPosition.transform.position.y));
        enemySpawner.timer = 0;
        enemySpawner.InitMonster(new Vector2(shootPosition.transform.position.x - 0.0f, shootPosition.transform.position.y));
        enemySpawner.timer = 0;
        enemySpawner.InitMonster(new Vector2(shootPosition.transform.position.x + 1.5f, shootPosition.transform.position.y));
       
    }
    
    void BossShootBottle()
    {
        int Bottle = Random.Range(1, 3);

        switch(Bottle)
        {
            case 1: //빨간약병 빨간색 - 석궁에 맞거나 지나쳤을 시 폭발하여 큰 데미지, 요격 가능, 요격 시 폭발
                Instantiate(redBottle, new Vector3(shootPosition.transform.position.x, shootPosition.transform.position.y, 0), transform.rotation);
                break;
            case 2: //초록색 - 석궁에 맞을 시 2초간 공격 불가, 박사와 일직선일때 투척, 요격 불가, 속도가 빠름
                Instantiate(redBottle, new Vector3(shootPosition.transform.position.x, shootPosition.transform.position.y, 0), transform.rotation);
                break;
            case 3: //보라색 - 몬스터에게 투척, 몬스터에 맞을 시 해당 몬스터 체력 증가 후 회복 & 속도 증가, 요격 가능, 속도 느림, 제일 먼 적한테 던짐
                Instantiate(redBottle, new Vector3(shootPosition.transform.position.x, shootPosition.transform.position.y, 0), transform.rotation);
                break;



        }


    }

    void Shoot() //보스 패턴 1 
    {
        //애니메이션 세팅 
        Instantiate(bullet, new Vector3(shootPosition.transform.position.x - 0.5f, shootPosition.transform.position.y, 0), transform.rotation);
        Instantiate(bullet, new Vector3(shootPosition.transform.position.x, shootPosition.transform.position.y, 0), transform.rotation);
        Instantiate(bullet, new Vector3(shootPosition.transform.position.x + 0.5f, shootPosition.transform.position.y, 0), transform.rotation);

    }




    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
    }


        IEnumerator Slow()
    {
        spd = startSpd * 0.2f;
        yield return new WaitForSeconds(2f);
        spd = startSpd;
    }
}
