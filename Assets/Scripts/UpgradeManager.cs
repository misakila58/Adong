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

    public List<Perks> itemList = new List<Perks>();

    void Update()
    {
        if (gameObject.activeSelf)
        {
            EnemySpawner.shopTime = true;
        }
        else
        {
            EnemySpawner.shopTime = false;
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
                break;
            case 1:
                PlayerStats.FireSpd -= 0.1f;
                break;
            case 2:
                PlayerStats.Spd += 0.1f;
                break;
            //case 3:
            //    PlayerStats.Spd += 0.1f;
            //    itemList.Remove(itemList[3]);
            //    itemList.Insert(3, nullPerk);
            //    break;
            //case 4:
            //    PlayerStats.Spd += 0.15f;
            //    itemList.Remove(itemList[4]);
            //    itemList.Insert(4, nullPerk);
            //    break;
            //case 5:
            //    PlayerPerks.semiAuto = true;
            //    itemList.Remove(itemList[5]);
            //    itemList.Insert(5, nullPerk);
            //    break;
            //case 6:
            //    PlayerStats.Hp++;
            //    perk.price += 200;
            //    break;
            //case 7:
            //    PlayerPerks.penetration = true;
            //    itemList.Remove(itemList[7]);
            //    itemList.Insert(7, nullPerk);
            //    break;
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
        //if (PlayerStats.Money >= itemList[saveTemp1].price)
        //{
        //AudioManager.instance.Play("buy");
        //PlayerStats.Money -= itemList[saveTemp1].price;
        //PlayerStats.FinalMoney += itemList[saveTemp1].price;
        //touchRange[0].GetComponent<Image>().color = new Color(0, 0, 0, 0.75f);
        //Button b = touchRange[0].GetComponent<Button>();
        //b.enabled = false;

        PlayerStats.UpgradeGage = 0;
        EnemySpawner.shopTime = false;
        gameObject.SetActive(false);

        ActivePerk(itemList[saveTemp1]);
        //}
    }
    public void TouchRange2()
    {
        //if (PlayerStats.Money >= itemList[saveTemp2].price)
        //{
        //AudioManager.instance.Play("buy");
        //PlayerStats.Money -= itemList[saveTemp2].price;
        //PlayerStats.FinalMoney += itemList[saveTemp2].price;
        //touchRange[1].GetComponent<Image>().color = new Color(0, 0, 0, 0.75f);
        //Button b = touchRange[1].GetComponent<Button>();
        //b.enabled = false;

        PlayerStats.UpgradeGage = 0;
        EnemySpawner.shopTime = false;
        gameObject.SetActive(false);

        ActivePerk(itemList[saveTemp2]);
        //}
    }
    public void TouchRange3()
    {
        //if (PlayerStats.Money >= itemList[saveTemp3].price)
        //{
        //AudioManager.instance.Play("buy");
        //PlayerStats.Money -= itemList[saveTemp3].price;
        //PlayerStats.FinalMoney += itemList[saveTemp3].price;
        //touchRange[2].GetComponent<Image>().color = new Color(0, 0, 0, 0.75f);
        //Button b = touchRange[2].GetComponent<Button>();
        //b.enabled = false;

        PlayerStats.UpgradeGage = 0;
        EnemySpawner.shopTime = false;
        gameObject.SetActive(false);

        ActivePerk(itemList[saveTemp3]);
        //}
    }

    void PickShopList()
    {
        var randomIndex = Random.Range(0, itemList.Count);
        while (itemList[randomIndex] == nullPerk)
        {
            randomIndex = Random.Range(0, itemList.Count);
        }
        saveItem = itemList[randomIndex];

        nameText[0].text = saveItem.name;
        descriptionText[0].text = saveItem.description;
        iconImage[0].sprite = saveItem.icon;
        //priceText[0].text = saveItem.price.ToString();

        saveTemp1 = randomIndex;
        PickShopList2();
    }
    void PickShopList2()
    {
        var randomIndex = Random.Range(0, itemList.Count);
        while (randomIndex == saveTemp1 || itemList[randomIndex] == nullPerk)
        {
            randomIndex = Random.Range(0, itemList.Count);
        }
        saveItem = itemList[randomIndex];

        nameText[1].text = saveItem.name;
        descriptionText[1].text = saveItem.description;
        iconImage[1].sprite = saveItem.icon;
        //priceText[1].text = saveItem.price.ToString();

        saveTemp2 = randomIndex;
        PickShopList3();
    }
    void PickShopList3()
    {
        var randomIndex = Random.Range(0, itemList.Count);
        while (randomIndex == saveTemp1 || randomIndex == saveTemp2 || itemList[randomIndex] == nullPerk)
        {
            randomIndex = Random.Range(0, itemList.Count);
        }
        saveItem = itemList[randomIndex];

        nameText[2].text = saveItem.name;
        descriptionText[2].text = saveItem.description;
        iconImage[2].sprite = saveItem.icon;
        //priceText[2].text = saveItem.price.ToString();

        saveTemp3 = randomIndex;
    }
}
