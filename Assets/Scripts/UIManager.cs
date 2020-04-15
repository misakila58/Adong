using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image upgradeGage;
    
    void Update()
    {
        upgradeGage.fillAmount = PlayerStats.UpgradeGage / 10f;
    }
}
