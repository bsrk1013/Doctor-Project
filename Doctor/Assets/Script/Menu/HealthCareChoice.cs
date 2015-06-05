using UnityEngine;
using System.Collections;

public class HealthCareChoice : MonoBehaviour
{
    public void LiverGameButton()
    {
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_LIVERGAME);
    }

    public void BackButton()
    {
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_MAIN);
    }
}