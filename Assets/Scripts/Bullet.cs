using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float spd;

    [HideInInspector]
    public int peneCount = 0;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.Translate(Vector2.up * spd * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            peneCount++;
        }

        if (peneCount >= 2)
            Destroy(gameObject);
    }
}
