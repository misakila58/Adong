using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Tutorial : MonoBehaviour
{
    public string[] Tuto_text = new string[4];
    public Text text;
    int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Tuto_text[a];
    }
    public void Tuto_right()
    {
        if (a<4)
        { a++; }
    }
    public void Tuto_left()
    {
        if (a > 0)
        { a--; }
    }
}
