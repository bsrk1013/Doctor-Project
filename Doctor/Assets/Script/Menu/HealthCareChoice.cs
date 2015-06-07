using UnityEngine;
using System.Collections;

public class HealthCareChoice : MonoBehaviour
{
    public GameObject ButtonSound;

    public void LiverGameButton()
    {
        Instantiate(ButtonSound);
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_LIVERGAME);
    }

    public void StomachGameButton()
    {
        Instantiate(ButtonSound);
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_STOMACHGAME);
    }

    public void DementiaGameButton()
    {
        Instantiate(ButtonSound);
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_DEMENTIAGAME);
    }

    public void BackButton()
    {
        Instantiate(ButtonSound);
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_MAIN);
    }
}