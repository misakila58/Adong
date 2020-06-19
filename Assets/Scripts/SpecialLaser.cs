using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialLaser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DestorySelf()
    {
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Crossbow")
        {
            PlayerStats.Hp = PlayerStats.Hp -5;
        }
    }

}
