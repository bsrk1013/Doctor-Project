using UnityEngine;
using System.Collections;

public abstract class QuizPlay : MonoBehaviour {

    protected UISprite CurrentHintPhoto;
    protected int CurrentStage;
    protected int CurrentHintNum;
    protected string CurrentBulletin;
    protected UILabel Label;    

	protected void Init()
    {
        CurrentStage = 1;
        CurrentHintNum = 0;
        CurrentHintPhoto = GetComponentInChildren<UISprite>();
        Label = GameObject.Find("Bulletin").GetComponent<UILabel>();
        Label.fontSize = 30;
        Label.fontStyle = FontStyle.Bold;
    }

    protected void NextStage()
    {
        ++CurrentStage;
        Debug.Log("현재 스테이지 : " + CurrentStage);
    }
    
    protected void CraeteHintPhoto(string _Name)
    {
        if (CurrentStage != (CurrentHintNum))
        {
            CurrentHintPhoto.spriteName = _Name + CurrentHintNum;
            ++CurrentHintNum;
        }
    }

    public abstract void SetQuizPhoto();
    public abstract void EndQuiz();    
}