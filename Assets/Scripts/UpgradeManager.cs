using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    //public BossSpawner bossSpawner;
    public DialougeManager dialougeManager;

    public Text[] nameText;
    public Text[] descriptionText;
    public Image[] iconImage;
    public GameObject[] touchRange;

    private Perks saveItem;
    private int saveTemp1;
    private int saveTemp2;
    private int saveTemp3;

    public Perks nullPerk;
    public PlayerPerks playerPerks;

    public GameObject swordPerkButton;
    public GameObject trapPerkButton;
    public GameObject laserPerkButton;

    public List<Perks> itemList = new List<Perks>();

    void Update()
    {
        if (gameObject.activeSelf)
        {
            EnemySpawner.shopTime = true;
        }
        else //다이얼로그 구현 중 여기서 계속 False로 바꿔줘서 다이얼로그 구현 시 애매한 부분이 있어 이부분 주석 처리 해놨음 바꿔야 되면 말해줘야함.
        {
      //      EnemySpawner.shopTime = false;
        }
    }

    void OnEnable()
    {
        PickShopList();
    }

    void OnDisable()
    {
        touchRange[0].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        Button b = touchRange[0].GetComponent<Button>();
        b.enabled = true;
        touchRange[1].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        Button b2 = touchRange[1].GetComponent<Button>();
        b2.enabled = true;
        touchRange[2].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        Button b3 = touchRange[2].GetComponent<Button>();
        b3.enabled = true;
    }

    public void NextButton()
    {
        //AudioManager.instance.Play("button");
        //enemySpawner.curStage++;
        //if (enemySpawner.curStage == enemySpawner.bossStage[0])
        //{
        //    EnemySpawner.bossTime = true;
        //    bossSpawner.StartCoroutine("SpawnBoss");
        //}
        //else if (enemySpawner.curStage == enemySpawner.bossStage[1])
        //{
        //    EnemySpawner.bossTime = true;
        //    bossSpawner.StartCoroutine("SpawnBoss2");
        //}
        //else if (enemySpawner.curStage == enemySpawner.bossStage[2])
        //{
        //    EnemySpawner.bossTime = true;
        //    bossSpawner.StartCoroutine("SpawnBoss3");
        //}
        //EnemySpawner.remainKill = enemySpawner.stage[enemySpawner.curStage - 1].remainKills;

        //EnemySpawner.waveReadyTime = true;
        //enemySpawner.StartCoroutine("WaveDraw");

        EnemySpawner.shopTime = false;
        gameObject.SetActive(false);
    }

    void ActivePerk(Perks perk)
    {
        switch (perk.index)
        {
            case 0:
                PlayerStats.Dmg += 5;
                itemList.Remove(itemList[0]);
                itemList.Insert(0, nullPerk);
                break;
            case 1:
                PlayerStats.FireSpd -= 0.1f;
                itemList.Remove(itemList[1]);
                itemList.Insert(1, nullPerk);
                break;
            case 2:
                PlayerStats.Spd += 0.2f;
                itemList.Remove(itemList[2]);
                itemList.Insert(2, nullPerk);
                break;
            case 3:
                PlayerStats.CriChan += 5f;
                itemList.Remove(itemList[3]);
                itemList.Insert(3, nullPerk);
                break;
            case 4:
                for (int i = 0; i < playerPerks.slots.Length; i++)
                {
                    if (playerPerks.isFull[i] == false)
                    {
                        playerPerks.isFull[i] = true;
                        Instantiate(swordPerkButton, playerPerks.slots[i].transform, false);
                        break;
                    }
                }
                itemList.Remove(itemList[4]);
                itemList.Insert(4, nullPerk);
                break;
            case 5:
                for (int i = 0; i < playerPerks.slots.Length; i++)
                {
                    if (playerPerks.isFull[i] == false)
                    {
                        playerPerks.isFull[i] = true;
                        Instantiate(trapPerkButton, playerPerks.slots[i].transform, false);
                        break;
                    }
                }
                itemList.Remove(itemList[5]);
                itemList.Insert(5, nullPerk);
                break;
            case 6:
                for (int i = 0; i < playerPerks.slots.Length; i++)
                {
                    if (playerPerks.isFull[i] == false)
                    {
                        playerPerks.isFull[i] = true;
                        Instantiate(laserPerkButton, playerPerks.slots[i].transform, false);
                        break;
                    }
                }
                itemList.Remove(itemList[6]);
                itemList.Insert(6, nullPerk);
                break;
            case 7:
                PlayerStats.Hp = PlayerStats.FullHp;
                break;
            //case 8:
            //    PlayerPerks.stunning = true;
            //    itemList.Remove(itemList[8]);
            //    itemList.Insert(8, nullPerk);
            //    break;
            //case 9:
            //    PlayerPerks.shotgun = true;
            //    itemList.Remove(itemList[9]);
            //    itemList.Insert(9, nullPerk);
            //    break;
            //case 10:
            //    PlayerPerks.focus = true;
            //    itemList.Remove(itemList[10]);
            //    itemList.Insert(10, nullPerk);
            //    break;
            //case 11:
            //    PlayerStats.FireSpd -= 0.05f;
            //    perk.price += 300;
            //    break;
            //case 12:
            //    PlayerPerks.homing = true;
            //    itemList.Remove(itemList[12]);
            //    itemList.Insert(12, nullPerk);
            //    break;
            //case 13:
            //    PlayerPerks.combo = true;
            //    itemList.Remove(itemList[13]);
            //    itemList.Insert(13, nullPerk);
            //    break;
            //case 14:
            //    PlayerPerks.sideShot = true;
            //    itemList.Remove(itemList[14]);
            //    itemList.Insert(14, nullPerk);
            //    break;
            default:
                break;
        }
    }

    public void TouchRange1()
    {
        enemySpawner.curKills = 0;        
        if (EnemySpawner.spawnType < 4)
            EnemySpawner.spawnType++;
        EnemySpawner.spawnDelay -= enemySpawner.spawnDelayReduceAmount;
        enemySpawner.remainKills += enemySpawner.remainKillsAddAmount;
        EnemySpawner.shopTime = false;
        gameObject.SetActive(false);

        ActivePerk(itemList[saveTemp1]);
        enemySpawner.curStage++;
    }
    public void TouchRange2()
    {
        enemySpawner.curKills = 0;
        if (EnemySpawner.spawnType < 4)
            EnemySpawner.spawnType++;
        EnemySpawner.spawnDelay -= enemySpawner.spawnDelayReduceAmount;
        enemySpawner.remainKills += enemySpawner.remainKillsAddAmount;
        EnemySpawner.shopTime = false;
        gameObject.SetActive(false);

        ActivePerk(itemList[saveTemp2]);
        enemySpawner.curStage++;
    }
    public void TouchRange3()
    {
        enemySpawner.curKills = 0;
        if (EnemySpawner.spawnType < 4)
            EnemySpawner.spawnType++;
        EnemySpawner.spawnDelay -= enemySpawner.spawnDelayReduceAmount;
        enemySpawner.remainKills += enemySpawner.remainKillsAddAmount;
        EnemySpawner.shopTime = false;
        gameObject.SetActive(false);

        ActivePerk(itemList[saveTemp3]);
        enemySpawner.curStage++;
    }

    void PickShopList()
    {
        int randomIndex = 0;

        if (enemySpawner.curStage == 1 || enemySpawner.curStage == 2)
        {
            randomIndex = Random.Range(0, 4);
            while (itemList[randomIndex] == nullPerk)
            {
                randomIndex = Random.Range(0, 4);
            }
            saveItem = itemList[randomIndex];
        }
        else if (enemySpawner.curStage >= 3 && enemySpawner.curStage <= 5)
        {
            randomIndex = Random.Range(4, 8);
            while (itemList[randomIndex] == nullPerk)
            {
                randomIndex = Random.Range(4, 8);
            }
            saveItem = itemList[randomIndex];
        }
        else if (enemySpawner.curStage >= 6)
        {
            randomIndex = Random.Range(8, 8);
            while (itemList[randomIndex] == nullPerk)
            {
                randomIndex = Random.Range(8, 8);
            }
            saveItem = itemList[randomIndex];
        }

        nameText[0].text = saveItem.name;
        descriptionText[0].text = saveItem.description;
        iconImage[0].sprite = saveItem.icon;

        saveTemp1 = randomIndex;
        PickShopList2();
    }
    void PickShopList2()
    {
        int randomIndex = 0;

        if (enemySpawner.curStage == 1 || enemySpawner.curStage == 2)
        {
            randomIndex = Random.Range(0, 4);
            while (randomIndex == saveTemp1 || itemList[randomIndex] == nullPerk)
            {
                randomIndex = Random.Range(0, 4);
            }
            saveItem = itemList[randomIndex];
        }
        else if (enemySpawner.curStage >= 3 && enemySpawner.curStage <= 5)
        {
            randomIndex = Random.Range(4, 8);
            while (randomIndex == saveTemp1 || itemList[randomIndex] == nullPerk)
            {
                randomIndex = Random.Range(4, 8);
            }
            saveItem = itemList[randomIndex];
        }
        else if (enemySpawner.curStage >= 6)
        {
            randomIndex = Random.Range(8, 8);
            while (randomIndex == saveTemp1 || itemList[randomIndex] == nullPerk)
            {
                randomIndex = Random.Range(0, itemList.Count);
            }
            saveItem = itemList[randomIndex];
        }

        nameText[1].text = saveItem.name;
        descriptionText[1].text = saveItem.description;
        iconImage[1].sprite = saveItem.icon;

        saveTemp2 = randomIndex;
        PickShopList3();
    }
    void PickShopList3()
    {
        int randomIndex = 0;

        if (enemySpawner.curStage == 1 || enemySpawner.curStage == 2)
        {
            randomIndex = Random.Range(0, 4);
            while (randomIndex == saveTemp1 || randomIndex == saveTemp2 || itemList[randomIndex] == nullPerk)
            {
                randomIndex = Random.Range(0, 4);
            }
            saveItem = itemList[randomIndex];
        }
        else if (enemySpawner.curStage >= 3 && enemySpawner.curStage <= 5)
        {
            randomIndex = Random.Range(4, 8);
            while (randomIndex == saveTemp1 || randomIndex == saveTemp2 || itemList[randomIndex] == nullPerk)
            {
                randomIndex = Random.Range(4, 8);
            }
            saveItem = itemList[randomIndex];
        }
        else if (enemySpawner.curStage >= 6)
        {
            randomIndex = Random.Range(8, 8);
            while (randomIndex == saveTemp1 || randomIndex == saveTemp2 || itemList[randomIndex] == nullPerk)
            {
                randomIndex = Random.Range(8, 8);
            }
            saveItem = itemList[randomIndex];
        }

        nameText[2].text = saveItem.name;
        descriptionText[2].text = saveItem.description;
        iconImage[2].sprite = saveItem.icon;

        saveTemp3 = randomIndex;
    }
}
