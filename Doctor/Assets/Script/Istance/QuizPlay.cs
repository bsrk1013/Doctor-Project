﻿using UnityEngine;
using System.Collections;

public abstract class QuizPlay : MonoBehaviour {

    public AudioClip[] Sound;
    public GameObject WrongButtonSound;
    public GameObject CorrectButtonSound;

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
        Instantiate(WrongButtonSound);
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
    
    protected void ChangeQuizSound()
    {
        if (Sound.Length <= CurrentHintNum)
        {
            return;
        }
        GetComponent<AudioSource>().clip = Sound[CurrentHintNum];
        GetComponent<AudioSource>().Play();
    }

    protected void CraeteHintPhoto(string _Name)
    {
        if (CurrentStage != (CurrentHintNum))
        {
            CurrentHintPhoto.spriteName = _Name + CurrentHintNum;
            ChangeQuizSound();
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