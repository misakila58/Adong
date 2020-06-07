﻿using System.Collections;
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

    public int bossSpecialStop; // 4가 되면 스탑 

    private float bossPattenTime;

    public float firstShotDelay;
    public float reloadTimer;
    private float timer;

    public float score;

   public int bossPhase;

    public GameObject bullet;
    public Transform shootPosition;

    public Image hpBar;

    public GameObject redBottle;
    public GameObject greenBottle;
    public GameObject purpleBottle;

    public GameObject[] bossSpecialMonster = new GameObject[4];

    public GameObject[] bossSpecialBullet = new GameObject[4];


    public GameObject boss2;

    public GameObject feather;

    private EnemySpawner enemySpawner;
    private Bottle bottle;
    private ActivePerks activePerks;
    private DialougeManager dialougeManager;
    private PlayerControl playerControl;

    public Animator anim;
    public Collider2D col;

    private int bossSpecialCount; // 임의의 숫자 반복 후 필살기 실행 

    void Start()
    {
        bossSpecialCount = 10;
        enemySpawner = GameObject.FindGameObjectWithTag("enemySpawner").GetComponent<EnemySpawner>();
        activePerks = GameObject.FindGameObjectWithTag("Crossbow").GetComponent<ActivePerks>();
        dialougeManager = GameObject.Find("GameManager").GetComponent<DialougeManager>();
        playerControl = GameObject.Find("Crossbow").GetComponent<PlayerControl>();

        if(bossPhase ==1)
        {
            bossPattenTime = 3;
            saveHp = 100;
            hp = saveHp;
            timer = firstShotDelay;
            spd = startSpd;
        }
        else if(bossPhase == 2)
        {
            bossPattenTime = 3;
            timer = firstShotDelay;
            saveHp = 200;
            hp = saveHp;
            spd = startSpd * 1.5f;
            TakeDamage(0);
        }
     
       
    }

    void Update()
    {
        if(EnemySpawner.shopTime == false)
        {
            timer -= Time.deltaTime;

            transform.Translate(Vector3.down * spd * Time.deltaTime);

            if (timer < 0)
            {
                Debug.Log("보스 패턴 들어감");
                int patten;
                if (bossPhase == 1)
                {
                    patten = Random.Range(1, 3);
                }
                else
                {
                    if(bossSpecialCount > 10)
                    {
                        patten = 5; // 필살기 
                    }
                    else
                    patten = Random.Range(4, 4);
                }
                switch (patten) // 1 ~ 2까지는 1페이즈 2페이즈부터는 3 ~ 5 
                {
                    case 1:
                        BossInitMonster();
                        timer = bossPattenTime;
                        break;
                    case 2: // 약병 던지는 패턴 
                        BossShootBottle();
                        timer = bossPattenTime;
                        break;
                    case 3: //날개 날리기 
                        BossShootFeather();
                        timer = bossPattenTime;
                        break;
                    case 4: // 하울링 
                        StartCoroutine(Howling());
                        timer = bossPattenTime;
                        break;
                    case 5: //필살기

                    default:
                        break;
                }
            }
        }
       


        //if (EnemySpawner.shopTime)
        //{
        //    Destroy(gameObject);
        //}
    
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
        
             // 보스전 승리 
            PlayerStats.Score += score;
            if (bossPhase == 1)
            {
                Destroy(this.gameObject);
                Instantiate(boss2, this.transform.position, transform.rotation);
            }
            else
            {
               
               // anim.SetTrigger("Die");
                dialougeManager.textNum = 12;
                dialougeManager.DialogueText();
                //죽는 애니메이션 이 후 Destory 함수로 오브젝트 삭제 필요 

            }
           
        }
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

    void BossShootBottle() // 패턴 2 약병 던지기 
    {
        int Bottle = Random.Range(2, 2);

        switch (Bottle)
        {
        case 1: //빨간약병 빨간색 - 석궁에 맞거나 지나쳤을 시 폭발하여 큰 데미지, 요격 가능, 요격 시 폭발
                Debug.Log("보스 약병 패턴1");
                
                Instantiate(redBottle, new Vector3(shootPosition.transform.position.x, shootPosition.transform.position.y, 0), transform.rotation);
        
                break;
        case 2: //초록색 - 석궁에 맞을 시 2초간 공격 불가, 박사와 일직선일때 투척, 요격 불가, 속도가 빠름
                Debug.Log("보스 약병 패턴2");
             
                Instantiate(greenBottle, new Vector3(shootPosition.transform.position.x, shootPosition.transform.position.y, 0), transform.rotation);
               
                break;
        case 3: //보라색 - 몬스터에게 투척, 몬스터에 맞을 시 해당 몬스터 체력 증가 후 회복 & 속도 증가, 요격 가능, 속도 느림, 제일 먼 적한테 던짐
                Debug.Log("보스 약병 패턴3");
               
               Instantiate(purpleBottle, new Vector3(shootPosition.transform.position.x, shootPosition.transform.position.y, 0), transform.rotation);
            
        break;
            default:
                break;
        }

    }
   
    void BossShootFeather() //패턴 3 날개 뿌리기 
    {
        Instantiate(feather, new Vector3(shootPosition.transform.position.x - 2.5f, shootPosition.transform.position.y, 0), transform.rotation);
        Instantiate(feather, new Vector3(shootPosition.transform.position.x, shootPosition.transform.position.y, 0), transform.rotation);
        Instantiate(feather, new Vector3(shootPosition.transform.position.x + 2.5f, shootPosition.transform.position.y, 0), transform.rotation);

    }

    IEnumerator Howling() //패턴 4 움직임 거꾸로 하기 
    {
        playerControl.isHowling = true;
        yield return new WaitForSeconds(2f);
        playerControl.isHowling = false;
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
    

    IEnumerator BossSpecialPatten()
    {
        //기모으는 애니메이션 시작


        for(int i =0; i<4; i++)
        {
            Instantiate(bossSpecialMonster[i], new Vector3((Random.Range(-2f, 3f)), Random.Range(4f, 2.5f), 0), transform.rotation);

        }


        yield return new WaitForSeconds(10f);

        playerControl.isHowling = false;
    }

}
