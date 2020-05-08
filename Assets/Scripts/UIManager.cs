using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image hpGage;
    public Image upgradeGage;
    public EnemySpawner enemySpawner;

    void Update()
    {
        hpGage.fillAmount = PlayerStats.Hp / PlayerStats.FullHp;
        upgradeGage.fillAmount = enemySpawner.curKills / enemySpawner.remainKills;
    }
}
