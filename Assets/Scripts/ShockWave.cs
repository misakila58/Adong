using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    public Animator anim;

    public static ShockWave instance;
    public Bottle bottle;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("shockWave");
        bottle = GameObject.Find("EnemySpawner").GetComponent<Bottle>();
        instance = this;
    


    }

    public void DestorySelf()
    {
        Destroy(gameObject);
    }

    public void NextWave()
    {
        bottle.ShockWaveInit(Boss.instance.boss.transform.position, Boss.instance.crossBowPosition);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Crossbow")
        {
            PlayerStats.Hp--;
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
