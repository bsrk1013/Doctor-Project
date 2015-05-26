using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeartAttckTalk : Talk
{
    public GameObject Quiz;

    void Start()
    {
        Init(40, true);
    }

    void FixedUpdate()
    {
        RunTime();

        DefaultTalk();

        EasingEvent(2,4);
    }

    public override void EndTalkEvent()
    {
        isTalking = false;
        BackGroundManager.getInstance().ChangeBackGround( BackGroundManager.SCENE_NUM.E_HEARTATTACK );
    }
}