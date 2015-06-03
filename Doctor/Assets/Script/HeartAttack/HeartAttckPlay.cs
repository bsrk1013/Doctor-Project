using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeartAttckPlay : GamePlay
{
    void Start()
    {
        Init(40, true);
    }

    void FixedUpdate()
    {
        RunTime();

        DefaultTalk();

        EasingEvent(3,5);
    }

    public override void EndTalkEvent()
    {
        isTalking = false;
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_HEARTATTACKQUIZ);
    }
}