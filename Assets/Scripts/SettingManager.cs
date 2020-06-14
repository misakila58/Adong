using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SettingManager : MonoBehaviour
{
    public GameObject optionPanel;
    public GameObject settingManager;

    private DialougeManager dialougeManager;
    public Tutorial tutorial; //Tutorial 함수 
    public GameObject tutorialPanel; // 튜토리얼 패널 

    public Text BGMValue;
    public Text SFXValue;

    public AudioMixer mixer;

    bool canStart = true;

    void Start()
    {
        //DontDestroyOnLoad(settingManager);//소리 관련을 이 오브젝트에서 다 처리해줄 것이기 떄문에 삭제 되면 안됨
        tutorial.LoadTutorialData();
        FirstGame();
        
        mixer.SetFloat("BGMVolume", PlayerPrefs.GetFloat("BGMVolume"));
        mixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));

        AudioManager.instance.Play("test");
        AudioManager.instance.Play("sfx");
    }

    void Update()
    {
        BGMValue.text = $"{PlayerPrefs.GetFloat("BGMVolume") + 20}";
        SFXValue.text = $"{PlayerPrefs.GetFloat("SFXVolume") + 20}";
    }

    void FirstGame() // 튜토리얼 패널 실행 함수 
    {
        if(tutorial.tutorialData.tutorialCheck == false)
        {
            tutorialPanel.SetActive(true);
        }
        else
        {
            tutorialPanel.SetActive(false);
        }
    }

    public void ExitTutorial()
    {
        tutorial.tutorialData.tutorialCheck = true;
        tutorialPanel.SetActive(false);
        tutorial.SaveTutorialData();
        canStart = true;
    }

    public void OnTutorial()
    {
        tutorialPanel.SetActive(true);
        canStart = false;
    }

    public void OptionButton()
    {
        if (!optionPanel.activeSelf)
        {
            optionPanel.SetActive(true);
            canStart = false;
        }            
        else
        {
            optionPanel.SetActive(false);
            canStart = true;
        }            
    }

    public void BGMLeftButton()
    {
        mixer.SetFloat("BGMVolume", PlayerPrefs.GetFloat("BGMVolume") - 2);
        PlayerPrefs.SetFloat("BGMVolume", PlayerPrefs.GetFloat("BGMVolume") - 2);
    }
    public void BGMRightButton()
    {
        mixer.SetFloat("BGMVolume", PlayerPrefs.GetFloat("BGMVolume") + 2);
        PlayerPrefs.SetFloat("BGMVolume", PlayerPrefs.GetFloat("BGMVolume") + 2);
    }

    public void SFXLeftButton()
    {
        mixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume") - 2);
        PlayerPrefs.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume") - 2);
    }
    public void SFXRightButton()
    {
        mixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume") + 2);
        PlayerPrefs.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume") + 2);
    }

    public void OptionCloseButton()
    {
        optionPanel.SetActive(false);
        canStart = true;
    }

    public void StartGame()
    {
        if (canStart)
            SceneManager.LoadScene("InGameScene");
    }

    public void EndGame()
    {
        Application.Quit();   
    }

}
