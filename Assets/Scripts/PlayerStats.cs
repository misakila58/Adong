using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Level;
    public int startLevel;

    public static float Dmg;
    public float startDmg;

    public static float FullHp;
    public static float Hp;
    public float startHp;

    public static float Spd;
    public float startSpd;

    public static float FireSpd;
    public float startFireSpd;

    public static float CriChan;
    public float startCriChan;

    public static float CriDmg;
    public float startCriDmg;

    public static float Score;

    void Start()
    {
        Level = startLevel;
        Dmg = startDmg;
        FullHp = startHp;
        Hp = startHp;
        Spd = startSpd;
        FireSpd = startFireSpd;
        CriChan = startCriChan;
        CriDmg = startCriDmg;
        Score = 0;
    }
}
