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

        EasingEvent(2, 4);
	}

    public override void EndTalkEvent()
    {
        isTalking = false;
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_CONCUSSIONQUIZ);
    }
}