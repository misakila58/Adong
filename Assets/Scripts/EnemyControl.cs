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

    // Start is called before the first frame update
    void Start()
    {
        hp = startHp;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * spd * Time.deltaTime);                
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Bullet")
        {
            Destroy(col.gameObject);

            hp -= 1;
            hpBar.gameObject.SetActive(true);
            hpBar.fillAmount = hp / startHp;

            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
