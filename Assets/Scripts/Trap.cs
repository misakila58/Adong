using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    void Update()
    {
        if (EnemySpawner.shopTime)
            Destroy(gameObject);
    }
}
