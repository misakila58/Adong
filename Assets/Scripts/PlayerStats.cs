using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Dmg;
    public int startDmg;

    public static int Hp;
    public int startHp;

    public static float Spd;
    public float startSpd;

    public static float FireSpd;
    public float startFireSpd;

    public static int Money;
    public int startMoney;

    void Start()
    {
        Dmg = startDmg;
        Hp = startHp;
        Spd = startSpd;
        FireSpd = startFireSpd;
        Money = startMoney;
    }
}
