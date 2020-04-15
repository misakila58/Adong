using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialougeManager : MonoBehaviour
{

    public EnemySpawner enemySpawner;
    public bool activeDialouge;


    public Text dialogue;
    public Image dialougeImage;

    public Sprite characterImage;
    public Sprite EnemyImage;

    

    string originDialogue;
    string subDialogue;

    [SerializeField]
    private int textNum;
    [SerializeField]
    private bool endTextCheck;
    

    // Start is called before the first frame update
    void Start()
    {
        activeDialouge = false;
        //   dialougeImage = GetComponent<Image>();

    }

    public void EndText()
    {
        endTextCheck = true;
    }

    public void DIalogueText()
    {
        EnemySpawner.shopTime = false;
        activeDialouge = true;
        Debug.Log("ㅁㄴㅇ");
            textNum++;
            switch (textNum)
            {
                case 1:

                     originDialogue = "옛날 옛날에 어느 산에 산을 호령하던 한 호랑이가 살고 있었습니다. ";
                     StartCoroutine(TypingAction());
                     endTextCheck = false;
                break;
                case 2:
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
                    originDialogue = "다른 동물들이 모두 사라진 호랑이는 인간들의 마을로 내려가보기로 하였습니다. ";
                    StartCoroutine(TypingAction());
                    endTextCheck = false;
                    break;
                case 5:
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
                originDialogue = "\"아이고 호랑이 어르신.. 저는 그저 농사를 짓는 일개 농부에 불과합니다. 저어쪽에 보이는 저 큰 집으로 한번 가보시지요\"  ";
                EnemySpawner.shopTime = true;
                break;
        }

        
        
 
       

    }
    void Update()
    {

    }

    IEnumerator TypingAction()
    {
    
            for (int i = 0; i < originDialogue.Length; i++)
            {
         

                yield return new WaitForSeconds(0.05f);

                subDialogue += originDialogue.Substring(0, i);
                dialogue.text = subDialogue;
                subDialogue = "";

            }
 
    
    }
}

