using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public Animator anim;

    public GameObject bullet;
    
    private float timer;
    
    void Update()
    {
        Shoot();

        if (timer <= PlayerStats.FireSpd && timer >= PlayerStats.FireSpd * 0.80f)
        {
            anim.SetInteger("timer", 1);
        }
        else if (timer <= PlayerStats.FireSpd * 0.80f && timer >= PlayerStats.FireSpd * 0.5f)
        {
            anim.SetInteger("timer", 2);
        }
        else if (timer <= PlayerStats.FireSpd * 0.5f)
        {
            anim.SetInteger("timer", 3);
        }
    }

    void Shoot()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(bullet, firePoint.transform.position, transform.rotation);

            timer = PlayerStats.FireSpd;
        }
    }
}
