using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePerks : MonoBehaviour
{
    public Transform swordPos;
    public LayerMask whatIsEnemies;
    public float swordRange;
    public int swordDmg;

    public float swordCoolDown;
    private float swordCurCoolDown;

    public GameObject swordObject;

    void Update()
    {
        swordCurCoolDown -= Time.deltaTime;
    }

    public void SwordSwing()
    {
        if (swordCurCoolDown <= 0)
        {
            GameObject s = Instantiate(swordObject, swordPos.position, transform.rotation);
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(swordPos.position, swordRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<EnemyControl>().TakeDamage(swordDmg);
            }
            swordCurCoolDown = swordCoolDown;
        }        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(swordPos.position, swordRange);
    }

    public void Trap()
    {
        Debug.Log("trap");
    }

    public void Laser()
    {
        Debug.Log("laser");
    }
}
