using UnityEngine;
using System.Collections;

public abstract class Talk : MonoBehaviour {

    public string[] TalkList;
    public float LimitTime;    

    protected UILabel Label;
    protected float CurrentTime;
    protected int CurrentTalkNum;
    protected int PlayCount;
    protected bool isTalking;    

    protected void Init( int _FontSize = 40, bool _isTalking = false )
    {
        CurrentTalkNum = 0;
        CurrentTime = 0;
        PlayCount = 0;
        Label = GetComponent<UILabel>();
        Label.fontSize = 40;
        isTalking = _isTalking;
    }

    // Update가 시작하자마자 실행
    protected void RunTime()
    {
        CurrentTime += RealTime.deltaTime;
    }

    protected void DefaultTalk()
    {
        if (LimitTime <= CurrentTime && isTalking)
        {
            NextTalk();
        }

        Label.text = TalkList[CurrentTalkNum];
    }

    protected void NextTalk()
    {
        if (TalkList.Length - 1 > CurrentTalkNum)
        {
            ++CurrentTalkNum;
        }
        else
        {
            EndTalkEvent();
        }
        CurrentTime = 0;
    }

    public void TouchWindow()
    {
        if (!isTalking)
        {
            return;
        }

        NextTalk();
    }

    protected void EasingEvent(params int[] _EventNum)
    {
        for (int i = 0; _EventNum.Length > i; ++i)
        {
            if (CurrentTalkNum == _EventNum[i])
            {
                BackGroundManager.getInstance().EasingBackGround(CurrentTalkNum);
            }
        }
    }

    public abstract void EndTalkEvent();
}