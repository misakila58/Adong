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

    public int bossSpecialStop; // 4가 되면 스탑 

    private float bossPattenTime;

    public float firstShotDelay;
    public float reloadTimer;
    private float timer;

    public float score;

    public static Boss instance;

   public int bossPhase;

    public GameObject bullet;
    public Transform shootPosition;

    public Image hpBar;

    public Image BossImage;
    public Sprite Boss2Image;
    public Sprite Boss2DieImage;
    public GameObject crossbow;
    public GameObject redBottle;
    public GameObject greenBottle;
    public GameObject purpleBottle;
    

    public GameObject specialLaser;
    public GameObject specialLaserShoot;

    public GameObject[] bossSpecialMonster = new GameObject[4];

    public GameObject[] bossSpecialBullet = new GameObject[4];

    public GameObject boss;

    public GameObject boss2;

    public GameObject feather;
    public GameObject soundWave;

    private EnemySpawner enemySpawner;
    public Bottle bottle;
    private ActivePerks activePerks;
    private DialougeManager dialougeManager;
    private PlayerControl playerControl;

    public Animator anim;
    public CircleCollider2D col;

    public  Vector3 crossBowPosition;
    private int bossSpecialCount; // 임의의 숫자 반복 후 필살기 실행 

    void Start()
    {
        instance = this;
        bossSpecialCount = 10;
        col = gameObject.GetComponent<CircleCollider2D>();
        enemySpawner = GameObject.FindGameObjectWithTag("enemySpawner").GetComponent<EnemySpawner>();
        activePerks = GameObject.FindGameObjectWithTag("Crossbow").GetComponent<ActivePerks>();
        dialougeManager = GameObject.Find("GameManager").GetComponent<DialougeManager>();
        playerControl = GameObject.Find("Crossbow").GetComponent<PlayerControl>();
        crossbow = GameObject.Find("Crossbow");
        bottle = GameObject.Find("EnemySpawner").GetComponent<Bottle>();
        bossPhase = 1;



        if (bossPhase ==1)
        {
            dialougeManager.textNum = 6;
            dialougeManager.DialogueText();
            bossPattenTime = 3;
            saveHp = 100;
            hp = saveHp;
            timer = firstShotDelay;
            spd = startSpd;
        }

        else if (bossPhase == 2)
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

            transform.Translate(Vector3.down * spd * Time.deltaTime);//좌우이동 

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
                        patten = 7; // 필살기 
                    }
                    else
                    patten = Random.Range(3, 7);
                }
                Debug.Log(patten);
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
                        BossShootFeatherLeft();
                        timer = bossPattenTime;
                        bossSpecialCount++;
                        break;
                    case 4: //날개 오른쪽
                        BossShootFeatherRight();
                        timer = bossPattenTime;
                        bossSpecialCount++;
                        break;
                    case 5: // 하울링 
                        StartCoroutine(Howling());
                        timer = bossPattenTime;
                        bossSpecialCount++;
                        break;
                    case 6: //충격파 
                        ShockWave();
                        timer = bossPattenTime;
                        bossSpecialCount++;
                        //충격파 애니메이션
                        break;
                    case 7: //필살기
                        StartCoroutine(BossSpecialPatten());
                        break;

                    default:
                        break;
                }
            }
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
        
             // 보스전 승리 
            PlayerStats.Score += score;
            if (bossPhase == 1)
            {
                BossPhase2();

            }
            else
            {
                dialougeManager.textNum = 12;
                dialougeManager.DialogueText();
              

            }
           
        }
    }

 public void BossImageChange()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Boss2Image;
    }

  public void BossPhase2()
    {

        this.gameObject.transform.localScale = new Vector3(1.0f, 1.0f);
        this.gameObject.transform.position = new Vector3(0, 3.0f);
        col.radius = 1f;
        bossPhase = 2;

        anim.SetTrigger("BossDie");
        bossPattenTime = 3;
        timer = firstShotDelay;
        saveHp = 200;
        hp = saveHp;
        spd = startSpd * 1.5f;
        TakeDamage(0);
    }

    void BossInitMonster() //보스 패턴 1 몬스터 생성 
    {
        //애니메이션 세팅 
        anim.SetTrigger("MonsterInit");
        enemySpawner.timer = 0;
        enemySpawner.InitMonster(new Vector2(shootPosition.transform.position.x - 1.5f, shootPosition.transform.position.y));
        enemySpawner.timer = 0;
        enemySpawner.InitMonster(new Vector2(shootPosition.transform.position.x - 0.0f, shootPosition.transform.position.y));
        enemySpawner.timer = 0;
        enemySpawner.InitMonster(new Vector2(shootPosition.transform.position.x + 1.5f, shootPosition.transform.position.y));
       
    }

    void BossShootBottle() // 패턴 2 약병 던지기 
    {
        int Bottle = Random.Range(1, 4);

        switch (Bottle)
        {
        case 1: //빨간약병 빨간색 - 석궁에 맞거나 지나쳤을 시 폭발하여 큰 데미지, 요격 가능, 요격 시 폭발
                Debug.Log("보스 약병 패턴1");
                anim.SetTrigger("BottleRed");
                Instantiate(redBottle, new Vector3(shootPosition.transform.position.x, shootPosition.transform.position.y, 0), transform.rotation);
        
                break;
        case 2: //초록색 - 석궁에 맞을 시 2초간 공격 불가, 박사와 일직선일때 투척, 요격 불가, 속도가 빠름
                Debug.Log("보스 약병 패턴2");
                anim.SetTrigger("BottleGreen");
                Instantiate(greenBottle, new Vector3(shootPosition.transform.position.x, shootPosition.transform.position.y, 0), transform.rotation);
               
                break;
        case 3: //보라색 - 몬스터에게 투척, 몬스터에 맞을 시 해당 몬스터 체력 증가 후 회복 & 속도 증가, 요격 가능, 속도 느림, 제일 먼 적한테 던짐
                Debug.Log("보스 약병 패턴3");
                anim.SetTrigger("BottlePurple");
                Instantiate(purpleBottle, new Vector3(shootPosition.transform.position.x, shootPosition.transform.position.y, 0), transform.rotation);
            
        break;
            default:
                break;
        }

    }
   
    void BossShootFeatherLeft() //패턴 3 날개 뿌리기 
    {
        anim.SetTrigger("LeftWing");
        Instantiate(feather, new Vector3(shootPosition.transform.position.x - 1.8f, shootPosition.transform.position.y, 0), Quaternion.Euler(0, 0, -13));
        Instantiate(feather, new Vector3(shootPosition.transform.position.x -0.7f, shootPosition.transform.position.y, 0), Quaternion.Euler(0, 0, -8.5f));
        Instantiate(feather, new Vector3(shootPosition.transform.position.x + 0.3f, shootPosition.transform.position.y, 0), Quaternion.Euler(0, 0, 10));
        Instantiate(feather, new Vector3(shootPosition.transform.position.x + 1.3f, shootPosition.transform.position.y, 0), Quaternion.Euler(0, 0, 10));

    }
    void BossShootFeatherRight() //패턴 3 날개 뿌리기 
    {
        anim.SetTrigger("RightWing");
        Instantiate(feather, new Vector3(shootPosition.transform.position.x - 1.2f, shootPosition.transform.position.y, 0), Quaternion.Euler(0, 0, -9));
        Instantiate(feather, new Vector3(shootPosition.transform.position.x - 0.0f, shootPosition.transform.position.y, 0), Quaternion.Euler(0, 0, 0));
        Instantiate(feather, new Vector3(shootPosition.transform.position.x + 1.5f, shootPosition.transform.position.y, 0), Quaternion.Euler(0, 0, 9));
    
    }

    IEnumerator Howling() //패턴 4 움직임 거꾸로 하기 
    {
        anim.SetTrigger("SoundWave");
        Instantiate(soundWave, new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, 0), transform.rotation);
        playerControl.isHowling = true;
        yield return new WaitForSeconds(2f);
        playerControl.isHowling = false;
    }

    void ShockWave() // 패턴5 충격파 
    {
        anim.SetTrigger("ShockWave");
        StartCoroutine(Timer());
        crossBowPosition = crossbow.transform.position;
        bottle.ShockWaveInit(this.gameObject.transform.position, crossBowPosition);
    }




    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
    }

    IEnumerator Timer1()
    {
        yield return new WaitForSeconds(1f);
    }


    IEnumerator Slow()
    {
        spd = startSpd * 0.2f;
        yield return new WaitForSeconds(2f);
        spd = startSpd;
    }
    

    IEnumerator BossSpecialPatten()
    {
        bossSpecialCount = 0;
        //기모으는 애니메이션 시작
        anim.SetTrigger("Special");

        timer = 20;
        Instantiate(specialLaser, new Vector3(this.transform.position.x, this.transform.position.y - 0.5f, 0), transform.rotation);
        for (int i =0; i<3; i++)
        {
            Instantiate(bossSpecialMonster[i], new Vector3((Random.Range(-2f, 3f)), Random.Range(4f, 2.5f), 0), transform.rotation);

        }


        yield return new WaitForSeconds(10f);
        Instantiate(specialLaserShoot, new Vector3(this.transform.position.x, this.transform.position.y - 0.5f, 0), transform.rotation);
        for (int i = 0; i < 3; i++)
        {
            Destroy(bossSpecialMonster[i]);

        }
        timer = bossPattenTime;

       
    }

}
