using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public bool activeDialouge;
    public GameObject textPanel;

    public Text dialogue;
    public Image dialougeImage;
    public GameObject DownArrow; //텍스트 끝났을 시 아래에서 깜빡일 오브젝트

    public Sprite characterImage;
    public Sprite EnemyImage;

    string originDialogue;
    string subDialogue;

    [SerializeField]
    private int textNum = 0;
    [SerializeField]
    private bool endTextCheck;
    
    // Start is called before the first frame update
    void Start()
    {
        endTextCheck = true;
        DialogueText();
        //   dialougeImage = GetComponent<Image>();
    }    

    public void DialogueText() // 다이얼로그 시작 부분에서 해당 함수를 실행 시켜주면 됨 
    {
        textPanel.SetActive(true);
        EnemySpawner.shopTime = true; // 텍스트 노출 시 멈추는 것을 하기 위해 이미 구현되어 있던 shopTime 을 가져다가 씀 

        if (endTextCheck == true)
        {
            textNum++;
            switch (textNum)
            {
                case 1:
                    dialougeImage.sprite = null; //왼쪽 이미지 창 
                    originDialogue = "옛날 옛날에 어느 산에 산을 호령하던 한 호랑이가 살고 있었습니다. "; // 나올 텍스트 
                    StartCoroutine(TypingAction()); // 시작 
                    endTextCheck = false;
                    break;
                case 2:
                    dialougeImage.sprite = null;
                    originDialogue = "그러던 어느날 산에 모든 동물들이 사라지고 말았습니다.";
                    StartCoroutine(TypingAction());
                    endTextCheck = false;
                    break;
                case 3:
                    dialougeImage.sprite = EnemyImage;
                    originDialogue = "\"다른 동물들이 모두 어디갔지??\"";
                
                    StartCoroutine(TypingAction());
                 
                    endTextCheck = false;
                    break;
                case 4:
                    dialougeImage.sprite = null;
                    originDialogue = "다른 동물들이 모두 사라진 호랑이는 인간들의 마을로 내려가보기로 하였습니다. ";
                    StartCoroutine(TypingAction());
                    endTextCheck = false;
                    break;
                case 5:
                    dialougeImage.sprite = EnemyImage;
                    originDialogue = "\"어흥! \n 인간! 우리 산에 동물들이 모두 안보이는데 혹시 어디로 갔는지 알고 있나!?\" ";
                    StartCoroutine(TypingAction());
                    endTextCheck = false;
                    break;
                case 6:
                    dialougeImage.sprite = characterImage;
                    originDialogue = "\"아이고 호랑이 어르신.. 저는 그저 농사를 짓는 일개 농부에 불과합니다. 저어쪽에 보이는 저 큰 집으로 한번 가보시지요\"  ";
                    StartCoroutine(TypingAction());
                    endTextCheck = false;
                    break;

                case 7:
                    textPanel.SetActive(false);
                    EnemySpawner.shopTime = false;
                    break;
            }
        }
        else
        {
            endTextCheck = true;
        } 
    }

    IEnumerator TypingAction() 
    {
        for (int i = 0; i < originDialogue.Length; i++)
        {
            yield return new WaitForSeconds(0.05f); //채팅 창 딜레이 

            subDialogue += originDialogue.Substring(0, i);
            dialogue.text = subDialogue;
            subDialogue = "";
            DownArrow.SetActive(false);
            if (endTextCheck == true)
            {
                dialogue.text = originDialogue;
                break;
            }
            if (i + 1 == originDialogue.Length) // 채팅의 끝까지 오면 엔드 텍스트를 활성화 시켜 다시 클릭 시 다음 창으로 넘어갈 수 있도록 변경 
            {
                endTextCheck = true;
                StartCoroutine(BlinkArrow());
            }
        }        
    }

    IEnumerator BlinkArrow()
    { 
        while(endTextCheck == true)
        {
            DownArrow.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            DownArrow.SetActive(false);
            yield return new WaitForSeconds(0.5f);
          
        }
    }
}

