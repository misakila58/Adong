using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialButton : MonoBehaviour
{

    private GameObject target;

    public GameObject[] specialButton = new GameObject[3];

   public int num;

    public static SpecialButton instance;


    private SpecialButton c_specialButton;
    private SpecialBullet c_specialBullet;

    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        c_specialButton = GameObject.Find("Boss").GetComponent<SpecialButton>();
        c_specialBullet = GameObject.Find("Boss").GetComponent<SpecialBullet>();
        instance = this;
      
    }


    public void SpecialButtonOn()
    {
        if(num == 0)
        {
            num = 1;
        }
        switch (num)
        {
            case 1: // 빨강 
                //Instantiate(specialButton[0], new Vector3(-2f, -3f, 0), transform.rotation);
                specialButton[0].transform.position = new Vector3(-2f, -3f, 0);
                GameObject a = Instantiate(specialButton[0], specialButton[0].transform.position, transform.rotation);
                a.name = "redButton";

                //specialButton[0].SetActive(true);
                //specialButton[1].SetActive(false);
                //specialButton[2].SetActive(false);
                break;
            case 2: // 초록 
                specialButton[1].transform.position = new Vector3(-2f, -3f, 0);
                GameObject b = Instantiate(specialButton[1], specialButton[1].transform.position, transform.rotation);
                b.name = "greenButton";

                //specialButton[0].SetActive(false);
                //specialButton[1].SetActive(true);
                //specialButton[2].SetActive(false);
                break;
            case 3: // 파랑 
                specialButton[2].transform.position = new Vector3(-2f, -3f, 0);
                GameObject c = Instantiate(specialButton[2], specialButton[2].transform.position, transform.rotation);
                c.name = "blueButton";

                //specialButton[0].SetActive(false);
                //specialButton[1].SetActive(false);
                //specialButton[2].SetActive(true);
                break;
            default:
                //specialButton[0].SetActive(false);
                //specialButton[1].SetActive(false);
                //specialButton[2].SetActive(false);
                break;

        }



    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            CastRay();

            if (target == this.gameObject)
            {  //타겟 오브젝트가 스크립트가 붙은 오브젝트라면
                
                if(target.gameObject.name =="redButton")
                {
                    c_specialBullet.RedBullet();
                }
                else if (target.gameObject.name == "greenButton")
                {
                    c_specialBullet.GreenBullet();
                }

              else  if (target.gameObject.name == "blueButton")
                {
                    c_specialBullet.BlueBullet();
                }



            }
        }
    }

    void CastRay() // 유닛 히트처리 부분.  레이를 쏴서 처리합니다. 

    {

        target = null;



        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);



        if (hit.collider != null)
        { //히트되었다면 여기서 실행

            Debug.Log(hit.collider.name);  //이 부분을 활성화 하면, 선택된 오브젝트의 이름이 찍혀 나옵니다. 

            target = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정

        }

    }
}
