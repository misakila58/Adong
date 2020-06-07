using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    public float spd;

    private int peneCount = 0;
    public float m_fSpeed = 5.0f;

    public bool shootArrow;

    Vector3 m_vecTarget;

    private GameObject target;

    void Start()
    {
        shootArrow = false;
     //   Destroy(gameObject, 5f);
    }




    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            CastRay();

            if (target == this.gameObject)
            {  //타겟 오브젝트가 스크립트가 붙은 오브젝트라면

                Shoot();

            }

        }

  
        if (shootArrow == true) 
        transform.Translate(Vector2.up * spd * Time.deltaTime);
    }



    public void Shoot()
    {
        shootArrow = true;
    }

    void CastRay() // 유닛 히트처리 부분.  레이를 쏴서 처리합니다. 

    {

        target = null;



        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);



        if (hit.collider != null)
        { //히트되었다면 여기서 실행

            Debug.Log (hit.collider.name);  //이 부분을 활성화 하면, 선택된 오브젝트의 이름이 찍혀 나옵니다. 

            target = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정

        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {

    }


}
