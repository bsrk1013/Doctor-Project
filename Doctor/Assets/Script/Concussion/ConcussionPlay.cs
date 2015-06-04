using UnityEngine;
using System.Collections;

public class ConcussionPlay : GamePlay
{

	// Use this for initialization
	void Start () {
        Init( 40, true );
	}
	
	// Update is called once per frame
	void Update () {
        RunTime();

        DefaultTalk();

        EasingEvent();

        ChangeTalkBox(5, "OldMan", "Concussion1");
        ChangeTalkBox(6, "YoungMan", "ConcussionBoy1");
	}

    public override void EndTalkEvent()
    {
        isTalking = false;
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_CONCUSSIONQUIZ);
    }
}