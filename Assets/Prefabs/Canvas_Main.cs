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
    bool Boss = true;
    public GameObject Boss1;
    public GameObject Boss2;

    public string[] Tuto_text = new string[4];
    public Text text;
    int a = 0;

    int Feather_Scale_Num = 0;
    public Text Feather_text;
    public GameObject Feather;
    bool Feather_switch = true;
    void Start()
    {
        Tutorial.SetActive(false);
        Setting.SetActive(false);
        MobAttack();
        MonsterHP.value = 1;

        
        Boss1.SetActive(true);
        Boss2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Tuto_text[a];
        Feather_text.text = Feather_Scale_Num.ToString();

        MonsterHP.value = Mhp / 1;
        Boss_Change();
    }

    public void Feather_Toggle()
    {
        Feather_switch = !Feather_switch;

        if (Feather_switch)
        {
            Feather.SetActive(true);
        }
        else if (!Feather_switch)
        {
            Feather.SetActive(false);
        }
    }
    public void Feather_Left()
    {
        GameObject Feather = GameObject.Find("Feather");
        float Xscale = Feather.transform.localScale.x;
        float Yscale = Feather.transform.localScale.y;
        float Zscale = Feather.transform.localScale.z;

        Xscale = Xscale - 0.1f;
        Yscale = Yscale - 0.1f;
        Zscale = Zscale - 0.1f;

        Feather.transform.localScale=new Vector3(Xscale, Yscale, Zscale);
        Feather_Scale_Num--;
    }
    public void Feather_Right()
    {
        GameObject Feather = GameObject.Find("Feather");
        float Xscale = Feather.transform.localScale.x;
        float Yscale = Feather.transform.localScale.y;
        float Zscale = Feather.transform.localScale.z;

        Xscale = Xscale + 0.1f;
        Yscale = Yscale + 0.1f;
        Zscale = Zscale + 0.1f;

        Feather.transform.localScale = new Vector3(Xscale, Yscale, Zscale);
        Feather_Scale_Num++;
    }
    public void Tuto_right()
    {
        if (a < 3)
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

    public void Animation_left()
    {
        Animation.Skill = -1;
    }
    public void Animation_right()
    {
        Animation.Skill = 1;
    }
    public void MobAttack()
    {
        Mhp = Mhp - 0.1f;

       
    }
    void ToBoss1()
    {
        Animation.Dead = false;
        Boss1.SetActive(true);
        Boss2.SetActive(false);
        Mhp = 1;
        Animation.Skill = 0;
        Boss = false;
    }
    void ToBoss2()
    {
        Animation.Dead = false;
        Boss1.SetActive(false);
        Boss2.SetActive(true);
        Mhp = 1;
        Animation.Skill = 0;
        Boss = false;
    }
    void Boss_Change()
    {
        if (Mhp <= 0 && Boss)
        {
            Debug.Log("Happened");
            Animation.Dead = true;
            Invoke("ToBoss2", 1f);
        }
        else if (Mhp <= 0 && !Boss)
        {
            Animation.Dead = true;
            Invoke("ToBoss1", 1f);
        }
    }
}
