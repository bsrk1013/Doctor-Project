using UnityEngine;
using System.Collections;

public class LiverGame : MonoBehaviour {

    private UISprite LiverEye;
    private int HP;

    void Start()
    {        
        HP = 3;
        LiverEye = GameObject.Find("LiverEye").GetComponent<UISprite>();
    }

    void Update()
    {
        if(0 == HP)
        {
            EndGame();
        }
    }

    public void MinusHP()
    {
        GameObject.Find("Heart" + HP).SetActive(false);
        --HP;
    }

    public void ChangeEye( string _Tag )
    {
        if("GoodFood" == _Tag)
        {
            LiverEye.spriteName = "SmileLiver";
        }
        else if("BadFood" == _Tag)
        {
            LiverEye.spriteName = "SadLiver";
        }
    }

    private void EndGame()
    {
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_FAIL, "LiverGameSucces");
    }
}