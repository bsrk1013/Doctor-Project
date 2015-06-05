using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeartAttckPlay : GamePlay
{
    void Start()
    {
        Init(40, true);
        Debug.Log( gameObject + "pos : " + transform.position );
    }

    void FixedUpdate()
    {
        RunTime();

        DefaultTalk();

        EasingEvent();

        ChangeTalkBox(5, "OldMan", "HeartAttack1");
        ChangeTalkBox(6, "YoungMan", "Boy1");
        ChangeTalkBox(7, "OldMan", "HeartAttack2");
    }

    public override void EndTalkEvent()
    {
        isTalking = false;
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_HEARTATTACKQUIZ);
    }
}