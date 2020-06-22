using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    public float spd;

    private int peneCount = 0;
    public GameObject[] specialBullet = new GameObject[3];

    public bool shootArrow;

    Vector3 m_vecTarget;

    private GameObject target;


    public Vector3 crossBowPosition;
    public GameObject crossBow;
    public int specialBulletType;
    private SpecialButton c_specialButton;
    private SpecialBullet c_specialBullet;
    private Boss boss;


    public static SpecialBullet instance;

    void Start()
    {
      
        c_specialButton = GameObject.Find("Boss").GetComponent<SpecialButton>();
        c_specialBullet = GameObject.Find("Boss").GetComponent<SpecialBullet>();
        boss = GameObject.Find("Boss").GetComponent<Boss>();
     
        instance = this;
        shootArrow = true;
     //   Destroy(gameObject, 5f);
    }
    
    void Update()
    {

       if (shootArrow == true) 
        transform.Translate(Vector2.up * spd * Time.deltaTime);
    }



    public void Shoot()
    {
        shootArrow = true;
    }

    public void RedBullet()
    {
        crossBow = GameObject.Find("Crossbow");
        crossBowPosition = crossBow.transform.position;
         Instantiate(specialBullet[0], crossBowPosition, transform.rotation);
           
    }
    public void GreenBullet()
    {
        crossBow = GameObject.Find("Crossbow");
        crossBowPosition = crossBow.transform.position;
        Instantiate(specialBullet[1], crossBowPosition, transform.rotation);
      
    }
    public void BlueBullet()
    {
        crossBow = GameObject.Find("Crossbow");
        crossBowPosition = crossBow.transform.position;
       Instantiate(specialBullet[2], crossBowPosition, transform.rotation);
      
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (specialBulletType)
        {
            case 1: //빨강 
                if(col.transform.tag =="M_red")
                {

                    c_specialButton.num =2;
                    c_specialButton.SpecialButtonOn();
                    Destroy(GameObject.Find("redButton"));
                    Destroy(gameObject);
                }
                break;

            case 2: // 초록 
                if (col.transform.tag == "M_green")
                {
                    c_specialButton.num = 3;
                    c_specialButton.SpecialButtonOn();
                    Destroy(GameObject.Find("greenButton"));
                    Destroy(gameObject);
                }
                break;

            case 3:// 파랑 
                if (col.transform.tag == "M_blue")
                {
                    c_specialButton.num = 0;
                    boss.StopSpecialPattern();
                    Destroy(GameObject.Find("blueButton"));
                    Destroy(gameObject);
                }
                break;

            default:
                break;

        }

    
    }

}
