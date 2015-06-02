using UnityEngine;
using System.Collections;

public class SnakeQuiz : QuizPlay {

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        SetBulletin();

        CraeteHintPhoto("SnakeHint");

        Label.text = CurrentBulletin;

        if( 3 == CurrentStage )
        {
            EndQuiz();
        }
	}

    public override void SetBulletin()
    {
        switch( CurrentStage )
        {
            case 1:
                {
                    CurrentBulletin = "119 연락!";
                    break;
                }
            case 2:
                {
                    CurrentBulletin = "독이 안퍼지게";
                    break;
                }
            case 3:
                {
                    CurrentBulletin = "상처를 씻자!";
                    break;
                }
            case 4:
                {
                    CurrentBulletin = "응급조치가 끝났다.";
                    break;
                }
        }
    }

    public override void EndQuiz()
    {
        BackGroundManager.getInstance().ChangeBackGround( BackGroundManager.SCENE_NUM.E_SUCCES );
    }

    public void Call119()
    {
        if (1 != CurrentStage)
        {
            Debug.Log("퀴즈 순서 틀림");            
            return;
        }

        NextStage();
    }
}