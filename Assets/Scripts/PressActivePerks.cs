using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressActivePerks : MonoBehaviour
{
    private GameObject crossbow;
    private GameObject firePoint;

    private ActivePerks activePerks;

    public int perkNum; // 1 = Sword  2 = trap  3 = laser
    public Image background;

    void Start()
    {
        crossbow = GameObject.FindGameObjectWithTag("Crossbow");
        firePoint = GameObject.FindGameObjectWithTag("FirePoint");
        activePerks = crossbow.GetComponent<ActivePerks>();
    }

    void Update()
    {
        if (perkNum == 1)
            background.fillAmount = activePerks.swordCurCoolDown / activePerks.swordCoolDown;
        else if (perkNum == 2)
            background.fillAmount = activePerks.trapCurCoolDown / activePerks.trapCoolDown;
        else if (perkNum == 3)
            background.fillAmount = activePerks.laserCurCoolDown / activePerks.laserCoolDown;
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
