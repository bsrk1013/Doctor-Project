using UnityEngine;
using System.Collections;

public class SnakeQuiz : QuizPlay {

    public GameObject Button119;
    public GameObject Silk;
    public GameObject SilkChoice;
    public GameObject UpSilkObj;
    public GameObject DownSilkObj;
    public GameObject Warter;
    public GameObject WarterZone;
    public GameObject RelaxButtonObj;

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        SetBulletin();

        CreateQuizPhoto("SnakeQuiz");
        CraeteHintPhoto("SnakeHint");

        Event();

        Label.text = CurrentBulletin;

        if (5 == CurrentStage || 0 == HP)
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
            case 4:
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
            BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_FAIL, "SnakeSucces");
            return;
        }
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_SUCCES, "SnakeSucces");
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
                    Button119.SetActive(true);
                    Silk.SetActive(false);
                    SilkChoice.SetActive(false);
                    Warter.SetActive(false);
                    WarterZone.SetActive(false);
                    RelaxButtonObj.SetActive(false);
                    isEvent = true;
                    break;
                }
            case 2:
                {
                    Button119.SetActive(false);
                    Silk.SetActive(true);
                    SilkChoice.SetActive(true);
                    UpSilkObj.SetActive(false);
                    DownSilkObj.SetActive(false);
                    isEvent = true;
                    break;
                }
            case 3:
                {
                    DownSilkObj.transform.parent.gameObject.SetActive(false);
                    Warter.SetActive(true);
                    WarterZone.SetActive(true);
                    isEvent = true;
                    break;
                }
            case 4:
                {
                    RelaxButtonObj.SetActive(true);
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

        Instantiate(CorrectButtonSound);

        NextStage();
    }

    public void UpSilk()
    {
        UpSilkObj.SetActive(true);
        UpSilkObj.transform.parent.GetComponent<BoxCollider>().enabled = false;

        Instantiate(CorrectButtonSound);

        NextStage();
    }

    public void DownSilk()
    {
        Instantiate(WrongButtonSound);
        MinusHP(); 
    }

    public void WarterDrop()
    {
        Instantiate(CorrectButtonSound);

        NextStage();
    }

    public void RelaxButton()
    {
        Instantiate(CorrectButtonSound);

        NextStage();
    }
}