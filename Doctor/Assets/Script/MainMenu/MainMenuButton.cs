using UnityEngine;
using System.Collections;

public class MainMenuButton : MonoBehaviour
{
	public void StartButton()
    {
        BackGroundManager.getInstance().ChangeBackGround( BackGroundManager.SCENE_NUM.E_HEARTATTACK);
    }
}