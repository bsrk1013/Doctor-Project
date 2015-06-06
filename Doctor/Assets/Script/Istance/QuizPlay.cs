using UnityEngine;
using System.Collections;

public abstract class QuizPlay : MonoBehaviour {

    protected UISprite CurrentHintPhoto;
    protected UISprite CurrentQuizPhoto;
    protected int CurrentStage;
    protected int CurrentHintNum;
    protected string CurrentBulletin;
    protected bool isEvent;
    protected UILabel Label;
    protected int HP;

    public void WrongButton()
    {
        GameObject.Find("Heart" + HP).SetActive(false);
        --HP;
    }

	protected void Init()
    {
        CurrentStage = 1;
        CurrentHintNum = 0;
        CurrentHintPhoto = GameObject.Find("HintPhoto").GetComponent<UISprite>();
        CurrentQuizPhoto = GameObject.Find("QuizPhoto").GetComponent<UISprite>();
        Label = GameObject.Find("Bulletin").GetComponent<UILabel>();
        Label.fontSize = 30;
        Label.fontStyle = FontStyle.Bold;
        isEvent = false;
        HP = 3;
    }

    protected void NextStage()
    {
        ++CurrentStage;
        isEvent = false;
    }
    
    protected void CraeteHintPhoto(string _Name)
    {
        if (CurrentStage != (CurrentHintNum))
        {
            CurrentHintPhoto.spriteName = _Name + CurrentHintNum;
            ++CurrentHintNum;
        }
    }

    protected void CreateQuizPhoto(string _Name)
    {
        if (CurrentStage != (CurrentHintNum))
        {
            CurrentQuizPhoto.spriteName = _Name + CurrentHintNum;
        }
    }

    protected void MinusHP()
    {
        GameObject.Find("Heart" + HP).SetActive(false);
        --HP;
    }

    public abstract void Event();
    public abstract void SetBulletin();
    public abstract void EndQuiz();
}