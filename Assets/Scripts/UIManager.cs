using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image upgradeGage;
    public EnemySpawner enemySpawner;

    void Update()
    {
        upgradeGage.fillAmount = enemySpawner.curKills / enemySpawner.remainKills;
    }
}
