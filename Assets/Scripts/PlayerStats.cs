using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Level;
    public int startLevel;

    public static int Dmg;
    public int startDmg;

    public static float FullHp;
    public static float Hp;
    public float startHp;

    public static float Spd;
    public float startSpd;

    public static float FireSpd;
    public float startFireSpd;

    public static int Money;
    public int startMoney;

    void Start()
    {
        Level = startLevel;
        Dmg = startDmg;
        FullHp = startHp;
        Hp = startHp;
        Spd = startSpd;
        FireSpd = startFireSpd;
        Money = startMoney;
    }
}
