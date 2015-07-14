using UnityEngine;
using System.Collections;

public class BackGroundManager : MonoBehaviour
{
    // 싱글톤
    private static BackGroundManager Instance;

    public static BackGroundManager getInstance()
    {
        if( !Instance )
        {
            Instance = GameObject.Find("Manager").GetComponent<BackGroundManager>();
        }

        return Instance;
    }

    public enum SCENE_NUM
    {
        E_SIMULATIONCHOICE = 0,
        E_HEARTATTACK,
        E_HEARTATTACKQUIZ,
        E_SUCCES,
        E_SNAKE,
        E_SNAKEQUIZ,
        E_CONCUSSION,
        E_CONCUSSIONQUIZ,
        E_MAIN,
        E_HEALTHCARECHOICE,
        E_LIVERGAME,
        E_FAIL,
        E_STOMACHGAME,
        E_DEMENTIAGAME,
        E_MENUALCHOICE,
        E_CENCERMENUAL,
        E_CARDIOVASCULARDISEASEMENUAL,
        E_DISABETESMELITUSMENUAL,
        E_HYPERTENSIONMENUAL,
        E_SUCCES2,
    };

    private enum SOUND_NUM
    {
        E_MAIN = 0,
        E_FAIL,
        E_SUCCES,
        E_SUCCES2,
        E_NONE,
    }

    public AudioClip[] Sound;
    public GameObject[] SceneList;
    public static float EasingStart;
    public static int EasingNum;

    private GameObject CurrentScene;    
    private float EasingTime;

    void Start()
    {
        ChangeBackGround(SCENE_NUM.E_MAIN);
        EasingStart = 0;
        EasingNum = -1;
    }

    private void ChangeMainSound(SOUND_NUM _Num)
    {
        GetComponent<AudioSource>().clip = Sound[(int)_Num];
        GetComponent<AudioSource>().loop = true;
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void ChangeBackGround(SCENE_NUM _Num, string _StageName = "")
    {
        Destroy(CurrentScene);
        CurrentScene = Instantiate(SceneList[(int)_Num]);

        if (_Num == SCENE_NUM.E_MAIN || _Num == SCENE_NUM.E_SIMULATIONCHOICE
            || _Num == SCENE_NUM.E_MENUALCHOICE || _Num == SCENE_NUM.E_HEALTHCARECHOICE)
        {
            ChangeMainSound(SOUND_NUM.E_MAIN);
        }
        else if (_Num == SCENE_NUM.E_SUCCES)
        {
            CurrentScene.GetComponent<GameExit>().StageName = _StageName;
            CurrentScene.GetComponent<UISprite>().spriteName = _StageName;
            CurrentScene.GetComponent<UIButton>().normalSprite = _StageName;
            ChangeMainSound(SOUND_NUM.E_SUCCES);
        }
        else if (_Num == SCENE_NUM.E_FAIL)
        {
            CurrentScene.GetComponent<GameExit>().StageName = _StageName;
            ChangeMainSound(SOUND_NUM.E_FAIL);
        }
        else if(_Num == SCENE_NUM.E_SUCCES2)
        {
            CurrentScene.GetComponent<GameExit>().StageName = _StageName;
            ChangeMainSound(SOUND_NUM.E_SUCCES2);
        }
        else
        {
            ChangeMainSound(SOUND_NUM.E_NONE);
        }
    }

    public GameObject GetCurrentScene()
    {
        return CurrentScene;
    }

    public void EasingBackGround( int _nNum )
    {
        if (-1 == EasingNum)
        {
            EasingNum = _nNum;
        }
        else if (_nNum == EasingNum && EasingStart > 0.5f)
        {
            return;
        }
        else if (_nNum != EasingNum && EasingStart > 0.5f)
        {
            EasingStart = 0.0f;
            EasingNum = _nNum;
        }

        EasingStart += RealTime.deltaTime;

        if (EasingStart <= 0.5f)
        {
            if (EasingTime > 0)
            {
                EasingTime -= RealTime.deltaTime;
            }
            else
            {
                EasingTime += RealTime.deltaTime;
            }

            CurrentScene.transform.position = new Vector3(0.0f, Mathf.Sin(EasingTime));
        }
        else
        {
            CurrentScene.transform.position = new Vector3(0.0f, 0.0f);
        }
    }
}