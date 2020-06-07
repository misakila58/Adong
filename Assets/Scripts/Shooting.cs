using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public Animator anim;

    public GameObject bullet;
    public Rigidbody2D rb;
    
    private float timer;

    public float movingShotCharge = 0;
    public GameObject movingShotBullet;

    public PlayerControl playerControl;
    public bool possibilityShoot;


    private void Start()
    {
        possibilityShoot = true;
    }
    void Update()
    {
        if (!EnemySpawner.shopTime && possibilityShoot == true)
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

        if (ActivePerks.MovingShot)
        {
            if (playerControl.isMove)
                movingShotCharge++;

            if (movingShotCharge >= 100 && !playerControl.isMove)
            {
                Instantiate(movingShotBullet, firePoint.transform.position, transform.rotation);
                movingShotCharge = 0f;
            }
        }
    }

    void Shoot()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(bullet, firePoint.transform.position, transform.rotation);

            ActivePerks.shootCount++;
            timer = PlayerStats.FireSpd;
        }
    }
}
