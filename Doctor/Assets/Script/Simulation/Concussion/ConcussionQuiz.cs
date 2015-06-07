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

        CreateQuizPhoto("ConcussionQuiz");
        CraeteHintPhoto("ConcussionHint");

        Event();

        if( 4 == CurrentStage || 0 == HP )
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
                    CurrentBulletin = "";
                    break;
                }
            case 2:
                {
                    CurrentBulletin = "";
                    break;
                }
            case 3:
                {
                    CurrentBulletin = "";
                    break;
                }
        }
    }

    public override void EndQuiz()
    {
        if (0 == HP)
        {
            Debug.Log("HERE");
            BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_FAIL, "ConcussionSucces");
            return;
        }
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_SUCCES, "ConcussionSucces");
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
        Instantiate(CorrectButtonSound);
        NextStage();
    }

    public void MouthButton()
    {
        Instantiate(CorrectButtonSound);
        NextStage();
    }

    public void HeadZoneButton()
    {
        Instantiate(CorrectButtonSound);
        NextStage();
    }
}