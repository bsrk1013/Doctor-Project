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
                    CurrentBulletin = "응급조치가 끝났다\n안정을취하자";
                    break;
                }
        }
    }

    public override void EndQuiz()
    {
        if (0 == HP)
        {
            BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_FAIL, "SnakeSucces");
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

        NextStage();
    }

    public void UpSilk()
    {
        UpSilkObj.SetActive(true);
        UpSilkObj.transform.parent.GetComponent<BoxCollider>().enabled = false;
        NextStage();
    }

    public void DownSilk()
    {
        MinusHP(); 
    }

    public void WarterDrop()
    {
        NextStage();
    }

    public void RelaxButton()
    {
        NextStage();
    }
}