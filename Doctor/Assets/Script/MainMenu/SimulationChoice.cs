using UnityEngine;
using System.Collections;

public class SimulationChoice : MonoBehaviour
{
	public void HeartAttackButton()
    {
        BackGroundManager.getInstance().ChangeBackGround( BackGroundManager.SCENE_NUM.E_HEARTATTACK);
    }

    public void SnakeButton()
    {
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_SNAKE);
    }

    public void ConcussionButton()
    {
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_CONCUSSION);
    }
}