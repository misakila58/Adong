using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image hpGage;
    public Image upgradeGage;
    public EnemySpawner enemySpawner;

    public Text scoreText;

    void Awake()
    {
        Screen.SetResolution(1080, 1920, true);
    }

    void Start()
    {
        AudioManager.instance.Stop("title");
        AudioManager.instance.Play("ingame");
    }

    void Update()
    {
        hpGage.fillAmount = PlayerStats.Hp / PlayerStats.FullHp;
        upgradeGage.fillAmount = enemySpawner.curKills / enemySpawner.remainKills;
        scoreText.text = PlayerStats.Score.ToString();
    }
}
