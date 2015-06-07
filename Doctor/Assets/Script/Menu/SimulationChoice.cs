using UnityEngine;
using System.Collections;

public class SimulationChoice : MonoBehaviour
{
    public GameObject ButtonSound;

	public void HeartAttackButton()
    {
        Instantiate(ButtonSound);
        BackGroundManager.getInstance().ChangeBackGround( BackGroundManager.SCENE_NUM.E_HEARTATTACK);
    }

    public void SnakeButton()
    {
        Instantiate(ButtonSound);
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_SNAKE);
    }

    public void ConcussionButton()
    {
        Instantiate(ButtonSound);
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_CONCUSSION);
    }

    public void BackButton()
    {
        Instantiate(ButtonSound);
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_MAIN);
    }
}