using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpeicialMonster : MonoBehaviour
{
    


   public int monsterType;
    private Boss boss;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10.0f);
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (monsterType)
        {
            case 1:
                if(col.transform.tag =="redBullet")
                {
                    Destroy(gameObject);
                }
                break;
            case 2:
                if (col.transform.tag == "greenBullet")
                {
                    Destroy(gameObject);
                }
                break;
            case 3:
                if (col.transform.tag == "blueBullet")
                {
                    Destroy(gameObject);

                }
                break;

        }


    }


}
