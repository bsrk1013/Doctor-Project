using UnityEngine;
using System.Collections;

public class SnakePlay : GamePlay {    

	void Start () {
        Init( 40, true );
	}
	
	// Update is called once per frame
	void Update () {
        RunTime();

        DefaultTalk();

        EasingEvent();

        ChangeTalkBox(3, "OldMan", "Snake1");
        ChangeTalkBox(5, "YoungMan", "Boy1");
	}

    public override void EndTalkEvent()
    {
        isTalking = false;
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_SNAKEQUIZ);
    }
}