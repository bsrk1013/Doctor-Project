using UnityEngine;
using System.Collections;

public class GameExit : MonoBehaviour
{
    public float Speed;
    public string StageName;

	private float Alpha;    
	
	// Use this for initialization
	void Start () {
		Alpha = 1.0f;
		GetComponent<UISprite> ().alpha = Alpha;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<UISprite> ().alpha > 0.0f) {
			Alpha -= Speed * RealTime.deltaTime;
			GetComponent<UISprite> ().alpha = Alpha;
		} else{
            SelectMenu();
		}
	}

    void SelectMenu()
    {
        switch(StageName)
        {
            case "LiverGameSucces":
            case "StomachGameSucces":
            case "DementiaGameSucces":
                {
                    BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_HEALTHCARECHOICE);
                    break;
                }
            case "SnakeSucces":
            case "HeartAttackSucces":
            case "ConcussionSucces":
                {
                    BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_SIMULATIONCHOICE);
                    break;
                }
        }
    }
}