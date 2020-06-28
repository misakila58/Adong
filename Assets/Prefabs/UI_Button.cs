using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    public Image hpbar;
    public string[] Intro_text = new string[4];
    public Text text;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Mob_HPSlider();

    }

    void Mob_HPSlider()
    {
        float HP = gameObject.transform.parent.GetComponent<Monster>().MobHp;
        hpbar.fillAmount = HP / 100f;
    }

    void Intro_Plus()
    {
        GameObject Intro_Canvas = GameObject.Find("Intro_Canvas");
        int a = 0;
        if (a > 4)
        {
            text.text = Intro_text[4];
            gameObject.SetActive(false);
        }
        else
        {
            Intro_Canvas.SetActive(true);
            text.enabled = true;
            text.text = Intro_text[a];
        }
        a++;

    }
    void Intro_Minus()
    {
        GameObject Intro_Canvas = GameObject.Find("Intro_Canvas");
        int a = 0;
        if (a <0)
        {
            text.text=Intro_text[0]
            gameObject.SetActive(false);
        }
        else
        {
            Intro_Canvas.SetActive(true);
            text.enabled = true;
            text.text = Intro_text[a];
        }
        a++;
    }
}
