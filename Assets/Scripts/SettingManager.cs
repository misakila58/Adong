using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{

    public Toggle bgmButton;
    public Toggle soundButton;

    public GameObject settingPanel;
    public GameObject gameButton;
    public GameObject settingManager;

    private DialougeManager dialougeManager;
    public GameObject Obj_gameManager;

    // Start is called before the first frame update
    void Start()
    {
      
        DontDestroyOnLoad(settingManager); //소리 관련을 이 오브젝트에서 다 처리해줄 것이기 떄문에 삭제 되면 안됨
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BgmToggle()
    {
        if (bgmButton.isOn)
        {
            //사운드 소리 100
        }
        else
        {
            //사운드 소리 0 음소거 모드 
        }
    }

    public void SoundToggle()
    {
        if (bgmButton.isOn)
        {
            //사운드 소리 100
        }
        else
        {
            //사운드 소리 0 음소거 모드 
        }
    }

    public void ExitSettingPanel() //SettingPanel에 있는 X버튼 클릭 시 
    {
        settingPanel.SetActive(false);
        gameButton.SetActive(true);


    }
    public void OnSettingPanel() //Setting Button 활성화 시 
    {
        settingPanel.SetActive(true);
        gameButton.SetActive(false);
    }

    public void StartGame()
    {
        
        SceneManager.LoadScene("InGameScene");

     
    }

    public void EndGame()
    {
       
        Application.Quit();   
    }

}
