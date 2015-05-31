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
        E_MAIN = 0,
        E_HEARTATTACK,
        E_HEARTATTACKQUIZ,
        E_SUCCES
    };

    public GameObject[] SceneList;
    public static float EasingStart;
    public static int EasingNum;

    private GameObject CurrentScene;    
    private float EasingTime;

    void Start()
    {
        CurrentScene = Instantiate(SceneList[(int)SCENE_NUM.E_MAIN]);
        EasingStart = 0;
        EasingNum = -1;
    }

    public void ChangeBackGround(SCENE_NUM _Num)
    {
        Destroy(CurrentScene);
        CurrentScene = Instantiate(SceneList[(int)_Num]);
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