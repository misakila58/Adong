using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Main : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Tutorial;
    public GameObject Setting;
    public Slider MonsterHP;
    float Mhp = 1;

    public string[] Tuto_text = new string[4];
    public Text text;
    int a = 0;
    void Start()
    {
        Tutorial.SetActive(false);
        Setting.SetActive(false);
        MobAttack();
        MonsterHP.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Tuto_text[a];
    }


    
    public void Tuto_right()
    {
        if (a < 4)
        { a++; }
    }
    public void Tuto_left()
    {
        if (a > 0)
        { a--; }
    }
    public void Close()
    {
        Tutorial.SetActive(false);
        Setting.SetActive(false);
    }
    public void Set_Tutorial()
    {
        Tutorial.SetActive(true);
    }

    public void Set_Setting()
    {
        Setting.SetActive(true);
    }

    void Animation_left()
    {

    }
    void Animation_right()
    {

    }
    public void MobAttack()
    {
        Mhp = Mhp - 0.1f;
        MonsterHP.value = Mhp / 1;
    }
}
