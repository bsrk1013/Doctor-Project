using UnityEngine;
using System.Collections;

public class ConcussionQuiz : QuizPlay {

    public GameObject Mouth;
    public GameObject MouthButtonObj;
    public GameObject Blood;
    public GameObject Band;
    public GameObject HeadBand;
    public GameObject HeadZone;
    public GameObject MentalCheckButton;

    void Start()
    {
        Init();
    }

    void Update()
    {
        SetBulletin();

        Label.text = CurrentBulletin;

        CraeteHintPhoto("ConcussionHint");

        Event();

        if( 4 == CurrentStage )
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
                    CurrentBulletin = "기도확보가 중요하다!";
                    break;
                }
            case 2:
                {
                    CurrentBulletin = "출혈을 막자!";
                    break;
                }
            case 3:
                {
                    CurrentBulletin = "환자의 의식을 확인하자!";
                    break;
                }
        }
    }

    public override void EndQuiz()
    {
        BackGroundManager.getInstance().ChangeBackGround( BackGroundManager.SCENE_NUM.E_SUCCES );
    }

    public override void Event()
    {
        if (isEvent)
        {
            return;
        }


        switch (CurrentStage)
        {
            case 1:
                {
                    MentalCheckButton.SetActive(false);
                    isEvent = true;
                    break;
                }
            case 2:
                {
                    Mouth.SetActive(true);
                    Band.SetActive(true);
                    HeadZone.SetActive(true);
                    MouthButtonObj.SetActive(false);
                    isEvent = true;
                    break;
                }
            case 3:
                {
                    HeadBand.SetActive(true);
                    Blood.SetActive(false);
                    MentalCheckButton.SetActive(true);
                    isEvent = true;
                    break;
                }
        }
    }

    public void MentalChckButton()
    {
        NextStage();
    }

    public void MouthButton()
    {        
        NextStage();
    }

    public void HeadZoneButton()
    {
        NextStage();
    }
}