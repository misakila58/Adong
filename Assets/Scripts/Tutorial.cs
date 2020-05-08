using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TutorialData
{
    public bool tutorialCheck = true; // true면 실행 false면 한번 실행했던 걸로 간주 

}



public class Tutorial : MonoBehaviour
{

    public TutorialData tutorialData = new TutorialData(); // Json 파일 생성된 내용을 저장하는 함수 


    // Start is called before the first frame update
    void Start()
    {
        LoadTutorialData();
    }



    public void SaveTutorialData() //Json 파일 생성  
    {
        string str = JsonUtility.ToJson(tutorialData);
        File.WriteAllText(Application.dataPath + "/TestJson.json", JsonUtility.ToJson(tutorialData));

    }

   

  public  void LoadTutorialData() //Json 파일 불러오기 
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



