﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Swoosh(){
        GameObject.Find("Music").GetComponent<MusicManager>().PlaySwooshSound();
    }
}
