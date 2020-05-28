using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneTextControl : MonoBehaviour
{
    public GameObject StartText;
    private bool blinkText;

    // Start is called before the first frame update
    void Start()
    {
        blinkText = true;
        StartCoroutine(Blink());

    }

    // Update is called once per frame
    void Update()
    {
     

    }

    IEnumerator Blink()
    {
        while(blinkText == true)
        {
           
            StartText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            StartText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
