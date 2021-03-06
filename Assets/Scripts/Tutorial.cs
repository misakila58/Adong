﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class TutorialData
{
   
    public bool tutorialCheck; // false 면 처음 true이면 실행했떤 것 

}



public class Tutorial : MonoBehaviour
{

    
    public TutorialData tutorialData = new TutorialData(); // Json 파일 생성된 내용을 저장하는 함수 
    public int tutorialNum;
    public Text tutorialPageNum; // 좌측 위 숫자 표시 
    
    // Start is called before the first frame update
    void Awake()
    {

    }

    public void TutorialLeft()
    {
        if(tutorialNum > 1)
        {
            tutorialNum--;
        }
        TutorialContents();
    }

    public void TutorialRight()
    {
        if (tutorialNum <4)
        {
            tutorialNum++;
        }
        TutorialContents();
    }
    
    public void TutorialContents()
    {

        switch (tutorialNum)
        {
            case 1:
                tutorialPageNum.text = "1/4";
                break;
            case 2:
                tutorialPageNum.text = "2/4";
                break;
            case 3:
                tutorialPageNum.text = "3/4";
                break;
            case 4:
                tutorialPageNum.text = "4/4";
                break;
        }


    }

    public void SaveTutorialData() //Json 파일 생성  
    {
        string str = JsonUtility.ToJson(tutorialData);
        File.WriteAllText(Application.dataPath + "/TestJson.json", JsonUtility.ToJson(tutorialData));
        Debug.Log(Application.dataPath);

    }

   

  public void LoadTutorialData() //Json 파일 불러오기 
    {
       
        string str2 = File.ReadAllText(Application.dataPath + "/TestJson.json");
        tutorialData = JsonUtility.FromJson<TutorialData>(str2);
        Debug.Log(tutorialData.tutorialCheck);
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}



