using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    public Animator anim;

    public static ShockWave instance;

    // Start is called before the first frame update
    void Start()
    {
        

        instance = this;
    


    }

    public void DestorySelf()
    {
        Destroy(gameObject);
    }

    public void NextWave()
    {
        Bottle.instance.ShockWaveInit(Boss.instance.boss2.transform.position,Boss.instance.crossBowPosition);
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
