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

    public Sprite[] cutScenes;

    string originDialogue;
    string subDialogue;

    [SerializeField]
    public int textNum = 0;
    [SerializeField]
    private bool endTextCheck;
    
    // Start is called before the first frame update
    void Start()
    {
        endTextCheck = true;
        DialogueText();
        //DialogueText();
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
                    dialougeImage.sprite = cutScenes[0]; //왼쪽 이미지 창 
                    originDialogue = "아펜도스 마을은 평화로운 빛의 가호가 내려진 많은 마을들 중 하나다." + "\n" +
                        "알렌은 그런 마을의 평범한 가정에서 자란 사냥꾼이었다. 그러던 어느 날, 마을에 어두운 그림자가 내려앉게 된다. "; // 나올 텍스트 
                    StartCoroutine(TypingAction()); // 시작 
                    endTextCheck = false;
                    break;
                case 2:
                    dialougeImage.sprite = cutScenes[1];
                    originDialogue = "알렌" + "\n" + "\"우리 마을이 왜 불타고 있는 거지?\"";
                    StartCoroutine(TypingAction());
                    endTextCheck = false;
                    break;
                case 3:
                    dialougeImage.sprite = cutScenes[2];
                    originDialogue = "난장판이 된 집 앞에 도착한 알렌은 불길한 예감에 휩싸여 늘 가지고 다니던 석궁을 단단히" +
                        " 쥐고 주변을 살폈다. 불쌍한 알렌! 그는 이미 잔인한 운명으로 한 걸음 다가서고 있었다. ";
                
                    StartCoroutine(TypingAction());
                 
                    endTextCheck = false;
                    break;
                case 4:
                    dialougeImage.sprite = cutScenes[3];
                    originDialogue = "그가 마주한 광경은 참혹했다. 괴물들이 이곳저곳을 뒤지며 으르렁거렸고, 고깃덩이를 씹어 삼키느라 정신이 없었다." +
                        " 분노에 찬 알렌은 석궁을 조준해 괴물들을 하나씩 죽여 나갔다. 마지막 괴물을 베어낸 후 그는 묵묵히 바깥을 향해 돌아섰다. ";
                    StartCoroutine(TypingAction());
                    endTextCheck = false;
                    break;
                case 5:
                    dialougeImage.sprite = cutScenes[4];
                    originDialogue = "나약한 눈물은 흐르지 않았다. 오직 불타오르는 증오만이 그의 가슴에 자리 잡아 방아쇠를 당겼다." +
                        " 그는 이를 악물고 어느새 주위를 둘러싼 괴물들의 목을 노려봤다. 그 길의 끝에, 무엇이 있을지 모르는 채로... 끔찍한 절망감에 사로잡혀서. ";
                    StartCoroutine(TypingAction());
                    endTextCheck = false;
                    break;

                case 6://첫 다이얼로그 종료 
                    textPanel.SetActive(false);
                    EnemySpawner.shopTime = false;
                    break;

                case 7: // 보스전 시작 
                    dialougeImage.sprite = cutScenes[5]; //왼쪽 이미지 창 
                    originDialogue = "알렌" +
                        "\n" +
                        "네놈 짓이군. 빌어먹은 것들을 버려둔 게. "; // 나올 텍스트 
                    StartCoroutine(TypingAction()); // 시작 
                    endTextCheck = false;
                    break;
                case 8: 
                    dialougeImage.sprite = cutScenes[5]; //왼쪽 이미지 창 
                    originDialogue = "닥터 크로우" +
                        "\n" +
                        "공포를 찾는 방랑자가 또 겁 없이 기어들어 왔구나. 그래, 내가 친히 풀어준 죽음이 마음에 드는가? "; // 나올 텍스트 
                    StartCoroutine(TypingAction()); // 시작 
                    endTextCheck = false;
                    break;
                case 9:
                    dialougeImage.sprite = cutScenes[5]; //왼쪽 이미지 창 
                    originDialogue = "알렌" +
                        "\n" +
                        "왜 그런 짓을 한 거지? "; // 나올 텍스트 
                    StartCoroutine(TypingAction()); // 시작 
                    endTextCheck = false;
                    break;
                case 10:
                    dialougeImage.sprite = cutScenes[5]; //왼쪽 이미지 창 
                    originDialogue = "닥터 크로우" +
                        "\n" +
                        "재미! 그리고 사랑! 파괴가 내 친구이며 절망이 내 무대이기 때문에. 인간들의 달콤한 비명, 불안에 잠겨 떨리는 눈동자까지... 너무나 가련하고" +
                        " 아름답지 않은가! 나를 원망하라, 복수심에 찬 이방인이여! 차오른 네 절망과 고통은 지루함에 한숨짓던 나날들의 새로운 기쁨이 될지니. "; // 나올 텍스트 
                    StartCoroutine(TypingAction()); // 시작 
                    endTextCheck = false;
                    break;
                case 11:
                    dialougeImage.sprite = cutScenes[5]; //왼쪽 이미지 창 
                    originDialogue = "알렌" +
                        "\n" +
                        "지긋지긋한 놈! 매일 밤 널 마주한 지금, 이 순간을 상상하지 않은 적이 없었다. 감히 바라건대, 시위에 매긴 화살이 네 심장을 빗나가지 않기를! "; // 나올 텍스트 
                    StartCoroutine(TypingAction()); // 시작 
                    endTextCheck = false;
                    break;
                case 12://보스전 다이얼로그 종료 
                    textPanel.SetActive(false);
                    EnemySpawner.shopTime = false;
                    break;
                case 13: // 보스전 승리 시 다이얼로그 시작 TextNum 을 12로 설정 해줘야 함 
                    dialougeImage.sprite = cutScenes[6]; //왼쪽 이미지 창 
                    originDialogue = "닥터 크로우" +
                        "\n" +
                        "하하... 통쾌한 복수로다! 네 화살이 나를 죽였다. 가소롭구나, 변두리의 영웅이여... 작은 승리에 취해 세상의 혼돈을 외면하겠나? ";
                    StartCoroutine(TypingAction()); // 시작 
                    endTextCheck = false;
                    break;
                case 14: 
                    dialougeImage.sprite = cutScenes[6]; //왼쪽 이미지 창 
                    originDialogue = "알렌" +
                        "\n" +
                        "아무도 너를 기억하지 못할 것이고, 죽음조차 너의 파멸을 잊을 것이다. 나의 복수는 네 숨을 끊는 것이 전부가 아니야. 너의 끔찍한 죄악들도 함께 지옥으로 쳐박고 흔적을 모조리 불태울 테다! ";
                    StartCoroutine(TypingAction()); // 시작 
                    endTextCheck = false;
                    break;
                case 15:
                    dialougeImage.sprite = cutScenes[6]; //왼쪽 이미지 창 
                    originDialogue = "닥터 크로우" +
                        "\n" +
                        "네가 죽는 날까지 넌 오늘의 승리를 기억하겠지. 나는 죽어도 죽지 않는다! 너의 끔찍한 기억 속에서 영원히 불명하리라! 아아, 난 참으로. 운이... 좋구나... ";
                    StartCoroutine(TypingAction()); // 시작 
                    endTextCheck = false;
                    break;
                case 16:
                    textPanel.SetActive(false);
                    EnemySpawner.shopTime = false;
                    break;
                case 17://보스 패배 시 다이얼로그 시작 TextNum 을 16으로 설정 해줘야 함 
                    dialougeImage.sprite = cutScenes[0]; //왼쪽 이미지 창 
                    originDialogue = "알렌" +
                        "\n" +
                        "여기서 쓰러지다니, 나의 분노가 부족했단 말인가... ";
                    StartCoroutine(TypingAction()); // 시작 
                    endTextCheck = false;
                    break;
                case 18:
                    dialougeImage.sprite = cutScenes[0]; //왼쪽 이미지 창 
                    originDialogue = "닥터 크로우" +
                        "\n" +
                        "증오는 낡아 허물어졌고, 화살은 살가죽 하나 뚫지 못할 정도로 무뎌졌구나. 어리석고 가엾은 자여! 네 덕에 나는 또 하염없이 기쁨을 기다려야 하나니... ";
                    StartCoroutine(TypingAction()); // 시작 
                    endTextCheck = false;
                    break;
                case 19://보스 패배시 다이얼로그 종료
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

