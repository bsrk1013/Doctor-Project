using UnityEngine;
using System.Collections;

public class SnakePlay : GamePlay {

	// Use this for initialization
	void Start () {
        Init( 40, true );
	}
	
	// Update is called once per frame
	void Update () {
        RunTime();

        DefaultTalk();

        EasingEvent(3, 5);
	}

    public override void EndTalkEvent()
    {
        isTalking = false;
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_SNAKEQUIZ);
    }
}