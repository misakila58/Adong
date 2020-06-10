using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public ActivePerks activePerks;
    public Animator anim;

    void OnEnable()
    {
        Invoke("DisableLaser", activePerks.laserStartDuration);
    }

    void DisableLaser()
    {
        anim.SetTrigger("Off");
    }

    public void OffLaser()
    {
        gameObject.SetActive(false);
    }
}
