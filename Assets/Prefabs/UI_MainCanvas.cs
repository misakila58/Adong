using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Setting_On()
    {
        GameObject Setting_Canvas = GameObject.Find("Setting_Canvas");
        Setting_Canvas.SetActive(true);
    }

     void Pause_On()
    {
        GameObject Pause_Canvas = GameObject.Find("Pause_Canvas");
        Pause_Canvas.SetActive(true);
    }

    void Off()
    {
        gameObject.transform.parent.SetActive(false);
    }
    
}
