using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeartAttck : Talk {

    void Start()
    {
        Init();
    }

    void Update()
    {
        RunTime();

        DefaultTalk();
    }
}