﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float bgSpeed;
    public Renderer bgRend;

    void Update()
    {
        if (!PlayerStats.Died)
            bgRend.material.mainTextureOffset += new Vector2(0f, bgSpeed * Time.deltaTime);
    }
}
