using UnityEngine;
using System.Collections;

public class HealthCareChoice : MonoBehaviour
{
    public void LiverGameButton()
    {
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_LIVERGAME);
    }

    public void StomachGameButton()
    {
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_STOMACHGAME);
    }

    public void DementiaGameButton()
    {
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_DEMENTIAGAME);
    }

    public void BackButton()
    {
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_MAIN);
    }
}