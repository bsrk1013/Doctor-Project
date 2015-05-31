using UnityEngine;
using System.Collections;

public class HeartAttackQuiz : QuizPlay {
    
    private const int MaxCPR = 30;
    private const int MaxArtificialRespiration = 2; // 인공호흡
    private int CountCPR;
    private int CountArtificialRespiration;

	// Use this for initialization
	void Start () {
        CountCPR = 0;
        CountArtificialRespiration = 0;
        Init();        
	}
	
	// Update is called once per frame
	void Update () {        

        SetQuizPhoto();

       //CraeteHintPhoto("HeartAttack");

        Label.text = CurrentBulletin;

        if( 6 == CurrentStage )
        {
            EndQuiz();
        }
	}

    public override void SetQuizPhoto()
    {
        switch( CurrentStage )
        {
            case 1:
                {                    
                    CurrentBulletin = "119 연락!";
                    break;
                }
            case 2:
            case 4:
                {
                    CurrentBulletin = "가슴압박 : " + CountCPR;
                    break;
                }
            case 3:
            case 5:
                {
                    CurrentBulletin = "인공호흡 : " + CountArtificialRespiration;
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
            BackGroundManager.getInstance().EasingBackGround(-2);
            return;
        }


        NextStage();
    }

    public void CPR()
    {
        if (2 != CurrentStage && 4 != CurrentStage)
        {
            Debug.Log("퀴즈 순서 틀림");
            BackGroundManager.getInstance().EasingBackGround(-2);
            return;
        }

        ++CountCPR;
        Debug.Log("현재 CPR : " + CountCPR);

        if( MaxCPR == CountCPR )
        {
            NextStage();
            CountCPR = 0;
        }
    }

    public void ArtificialRespiration()
    {
        if (3 != CurrentStage && 5 != CurrentStage)
        {
            Debug.Log("퀴즈 순서 틀림");
            BackGroundManager.getInstance().EasingBackGround(-2);
            return;
        }

        ++CountArtificialRespiration;
        Debug.Log("현재 인공호흡 : " + CountArtificialRespiration);

        if( MaxArtificialRespiration == CountArtificialRespiration )
        {
            NextStage();
            CountArtificialRespiration = 0;
        }
    }
}