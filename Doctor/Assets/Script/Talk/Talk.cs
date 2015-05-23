using UnityEngine;
using System.Collections;

public abstract class Talk : MonoBehaviour {

    public string[] TalkList = new string[20];
    public float LimitTime;
    public int LimitTalkNum;

    protected UILabel Label;
    protected float CurrentTime;
    protected int CurrentTalkNum;

    protected void Init()
    {
        CurrentTalkNum = 0;
        CurrentTime = 0;
        Label = GetComponent<UILabel>();
        Label.fontSize = 40;
    }

    // Update가 시작하자마자 실행
    protected void RunTime()
    {
        CurrentTime += RealTime.deltaTime;
    }

    protected void DefaultTalk()
    {
        Label.text = TalkList[CurrentTalkNum];

        if( LimitTime <= CurrentTime )
        {
            NextTalk();
        }
    }

    protected void NextTalk()
    {
        if (LimitTalkNum > CurrentTalkNum)
        {
            ++CurrentTalkNum;
        }
        else
        {
            CurrentTalkNum = 0;
        }
        CurrentTime = 0;
    }

    public void TouchWindow()
    {
        NextTalk();
    }
}