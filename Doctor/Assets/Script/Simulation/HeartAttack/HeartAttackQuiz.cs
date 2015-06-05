using UnityEngine;
using System.Collections;

public class HeartAttackQuiz : QuizPlay {
    
    public GameObject Button119;
    public GameObject MouthButton;
    public GameObject CPRButton;

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

        SetBulletin();

       CraeteHintPhoto("HeartAttackHint");

       Event();

        Label.text = CurrentBulletin;

        if( 6 == CurrentStage || 0 == HP )
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
        if (0 == HP)
        {
            BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_SUCCES);
        }
        BackGroundManager.getInstance().ChangeBackGround( BackGroundManager.SCENE_NUM.E_SUCCES );
    }

    public override void Event()
    {
        if(isEvent)
        {
            return;
        }
        

        switch(CurrentStage)
        {
            case 1:
                {
                    Button119.SetActive(true);
                    MouthButton.SetActive(false);
                    CPRButton.SetActive(false);
                    isEvent = true;
                    break;
                }
            case 2:
            case 4:
                {
                    Button119.SetActive(false);
                    MouthButton.SetActive(false);
                    CPRButton.SetActive(true);
                    isEvent = true;
                    break;
                }
            case 3:
            case 5:
                {
                    Button119.SetActive(false);
                    MouthButton.SetActive(true);
                    CPRButton.SetActive(false);
                    isEvent = true;
                    break;
                }
        }
    }

    public void Call119()
    {
        if (1 != CurrentStage)
        {
            MinusHP();
            return;
        }        
        NextStage();
    }

    public void CPR()
    {
        if (2 != CurrentStage && 4 != CurrentStage)
        {
            MinusHP();
            return;
        }

        ++CountCPR;

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
            MinusHP();
            return;
        }

        ++CountArtificialRespiration;

        if( MaxArtificialRespiration == CountArtificialRespiration )
        {
            NextStage();
            CountArtificialRespiration = 0;
        }
    }
}