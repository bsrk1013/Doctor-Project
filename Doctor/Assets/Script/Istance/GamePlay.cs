using UnityEngine;
using System.Collections;

public abstract class GamePlay : MonoBehaviour
{
    public enum TALKOBJECT
    {
        E_YOUNGMAN = 0,
        E_OLDMAN,
        E_SNAKE,       
    }

    public string[] TalkList;
    public int[] TalkSubject;
    public GameObject[] TalkSubjectObject;
    public int[] EasingNum;
    public float LimitTime;

    protected UILabel Label;
    protected float CurrentTime;
    protected int CurrentTalkNum;
    protected int PlayCount;
    protected bool isTalking;
    protected Vector3[] TalkBoxPos = new Vector3[2];

    protected void Init( int _FontSize = 40, bool _isTalking = false )
    {
        CurrentTalkNum = 0;
        CurrentTime = 0;
        PlayCount = 0;
        Label = GetComponent<UILabel>();
        Label.fontSize = 40;
        isTalking = _isTalking;
        TalkBoxPos[1] = new Vector3(-0.4f, -0.7f); ;
        TalkBoxPos[0] = new Vector3(0.4f, -0.7f);        
    }

    // Update가 시작하자마자 실행
    protected void RunTime()
    {
        CurrentTime += RealTime.deltaTime;
    }

    protected void ChangeTalkBox(int _ChangeNum, string _ObjectName, string _SpriteName)
    {
        if( CurrentTalkNum == _ChangeNum )
        {
            GameObject.Find(_ObjectName).GetComponent<UISprite>().spriteName = _SpriteName;
        }
    }

    protected void DefaultTalk()
    {
        if (LimitTime <= CurrentTime && isTalking)
        {
            NextTalk();
        }

        for (int i = 0; TalkSubjectObject.Length > i; ++i )
        {
            if (TalkSubject[CurrentTalkNum] == i)
            {
                TalkSubjectObject[i].SetActive(true);

                if( 2 > i )
                {
                    transform.position = TalkBoxPos[i];
                }                
            }
            else
            {
                TalkSubjectObject[i].SetActive(false);
            }
        }

        Debug.Log("CurrentTalkNum : " + CurrentTalkNum);
        Debug.Log(TalkList[CurrentTalkNum]);
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

    protected void EasingEvent()
    {
        for (int i = 0; EasingNum.Length > i; ++i)
        {
            if (CurrentTalkNum == EasingNum[i])
            {
                BackGroundManager.getInstance().EasingBackGround(CurrentTalkNum);
            }
        }
    }

    public abstract void EndTalkEvent();
}