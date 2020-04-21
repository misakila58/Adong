using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressActivePerks : MonoBehaviour
{
    private GameObject crossbow;
    private GameObject firePoint;

    private ActivePerks activePerks;

    void Start()
    {
        crossbow = GameObject.FindGameObjectWithTag("Crossbow");
        firePoint = GameObject.FindGameObjectWithTag("FirePoint");
        activePerks = crossbow.GetComponent<ActivePerks>();
    }

    public void SwordSwing()
    {
        activePerks.SwordSwing();
    }

    public void Trap()
    {
        activePerks.Trap();
    }

    public void Laser()
    {
        activePerks.Laser();
    }
}
