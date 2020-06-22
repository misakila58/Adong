using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialLaser : MonoBehaviour
{
    public Animator anim;
    public static SpecialLaser instance;
    public bool failLaser;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void DestorySelf()
    {
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void FailLaser()
    {
        failLaser = true;
        anim.SetTrigger("FailLaser");
    }

    public void SuccessLaser()
    {
        AudioManager.instance.Stop("laserCast");
        AudioManager.instance.Play("laserShoot");
        failLaser = false;
        anim.SetTrigger("SuccessLaser");
     
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Crossbow" && failLaser == false)
        {
            PlayerStats.Hp = PlayerStats.Hp -5;
        }
    }

}
