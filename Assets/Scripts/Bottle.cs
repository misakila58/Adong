using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{

    public static Bottle instance;

    public GameObject redBottle; // case1
    public GameObject greenBottle; //case2
    public GameObject purpleBottle; //case3
    public GameObject boss;
    public GameObject boss2;
    public GameObject feather; //case 4

    private Shooting shooting;

    public List<GameObject> FoundObjects;
    public float shortDis;

    private Vector2 monsterPosion;
    public GameObject explosion;
 
    private EnemyControl enemyControl;

    public int bottleCase;


    public GameObject[] shockWave = new GameObject[3];


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        shooting = GameObject.FindGameObjectWithTag("Crossbow").GetComponent<Shooting>();
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        
    }

    public void ShockWaveInit(Vector3 boss,Vector3 crossbow)
    {


        if (GameObject.Find("shockWave0") == null && GameObject.Find("shockWave1") == null && GameObject.Find("shockWave2") == null)
        {
            shockWave[0].transform.position = Vector3.Lerp(boss, crossbow, 0.3f);
            GameObject a = Instantiate(shockWave[0], shockWave[0].transform.position, transform.rotation);
            a.name = "shockWave0";
        }

        else if (GameObject.Find("shockWave1") == null && GameObject.Find("shockWave0") != null && GameObject.Find("shockWave2") == null)
        {
            shockWave[1].transform.position = Vector3.Lerp(boss, crossbow, 0.6f);
            GameObject b = Instantiate(shockWave[1], shockWave[1].transform.position, transform.rotation);
            b.name = "shockWave1";
        }

        else if (GameObject.Find("shockWave2") == null && GameObject.Find("shockWave0") == null && GameObject.Find("shockWave1") != null)
        {
            shockWave[2].transform.position = Vector3.Lerp(boss, crossbow, 0.9f);
            GameObject c = Instantiate(shockWave[2], shockWave[2].transform.position, transform.rotation);
            c.name = "shockWave2";
        }



    }



    // Update is called once per frame
    void Update()
    {
        switch (bottleCase)
        {
            case 1:
                transform.Translate(Vector2.down * 2 * Time.deltaTime);
                break;
            case 2:
                transform.Translate(Vector2.down * 4 * Time.deltaTime);
                break;
            case 3: //날개 왼쪽 
                if(FoundObjects[0] == null)
                {
                    Destroy(gameObject);
                }
                Vector2 a = FoundObjects[0].transform.position;
                transform.Translate(a * 2 * Time.deltaTime);
                break;
            case 4: // 날개 오른쪽
                transform.Translate(Vector2.down * 3 * Time.deltaTime);
                break;
            case 5: // 충격파

            default:
                break;

        }



    }
        void OnTriggerEnter2D(Collider2D col)
    {
        switch (bottleCase)
        {

            case 1: //빨간약병 빨간색 - 석궁에 맞거나 지나쳤을 시 폭발하여 큰 데미지, 요격 가능, 요격 시 폭발
                if (col.transform.tag == "Bullet")
                {
                    Instantiate(explosion, new Vector3(this.transform.position.x, this.transform.position.y, 0),transform.rotation);
                    Destroy(this.gameObject); // 삭제 이펙트로 대체 후 제거 
                }
                if (col.transform.tag == "CrossBow")
                {
                    Instantiate(explosion, new Vector3(this.transform.position.x, this.transform.position.y, 0), transform.rotation);
                    Destroy(this.gameObject); // 삭제 이펙트로 대체 후 제거 
                }

                break;
            case 2://초록색 - 석궁에 맞을 시 2초간 공격 불가, 박사와 일직선일때 투척, 요격 불가, 속도가 빠름
                if (col.transform.tag == "Crossbow")
                {
                    StartCoroutine(PossibilityShoot());
                    this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }


                    break;
            case 3://보라색 - 몬스터에게 투척, 몬스터에 맞을 시 해당 몬스터 체력 증가 후 회복 & 속도 증가, 요격 가능, 속도 느림, 제일 먼 적한테 던짐
                if (col.transform.tag == "Enemy")
                {
                 //   Destroy(this.gameObject);
                }
                break;
            case 4: // 날개 왼쪽
                if (col.transform.tag == "Crossbow")
                {
                    PlayerStats.Hp--;
                    Destroy(gameObject);
                }
                break;
            case 5: //날개 오른쪽 
                if (col.transform.tag == "Crossbow")
                {
                    PlayerStats.Hp--;
                    Destroy(gameObject);
                }
                break;
            default:
                break;

        }

    }

    IEnumerator PossibilityShoot()
    {
        shooting.possibilityShoot = false;
        yield return new WaitForSeconds(2f);
        shooting.possibilityShoot = true;
       
    }
}
            
  
    

