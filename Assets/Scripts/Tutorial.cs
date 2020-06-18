using System.Collections;
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
        
    public GameObject[] tutoPanel;
    public GameObject leftArrow;
    public GameObject rightArrow;

    public int tutorialNum = 1;

    void Update()
    {
        if (tutorialNum == 1)
        {
            tutoPanel[0].SetActive(true);
            tutoPanel[1].SetActive(false);
            tutoPanel[2].SetActive(false);
            leftArrow.SetActive(false);
            rightArrow.SetActive(true);
        }
        else if (tutorialNum == 2)
        {
            tutoPanel[0].SetActive(false);
            tutoPanel[1].SetActive(true);
            tutoPanel[2].SetActive(false);
            leftArrow.SetActive(true);
            rightArrow.SetActive(true);
        }
        else if (tutorialNum == 3)
        {
            tutoPanel[0].SetActive(false);
            tutoPanel[1].SetActive(false);
            tutoPanel[2].SetActive(true);
            leftArrow.SetActive(true);
            rightArrow.SetActive(false);
        }
    }
     
    public void TutorialLeft()
    {
        if(tutorialNum > 1)
        {
            tutorialNum--;
        }
    }

    public void TutorialRight()
    {
        if (tutorialNum < 3)
        {
            tutorialNum++;
        }
    }

    public void SaveTutorialData() //Json 파일 생성  
    {
        string str = JsonUtility.ToJson(tutorialData);
        File.WriteAllText(Application.dataPath + "/TestJson.json", JsonUtility.ToJson(tutorialData));
        //Debug.Log(Application.dataPath);
    }

    public void LoadTutorialData() //Json 파일 불러오기 
    {
        string str2 = File.ReadAllText(Application.dataPath + "/TestJson.json");
        tutorialData = JsonUtility.FromJson<TutorialData>(str2);
      //Debug.Log(tutorialData.tutorialCheck);
    }

}



