using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void SimulationChoiceMenu()
    {
        BackGroundManager.getInstance().ChangeBackGround( BackGroundManager.SCENE_NUM.E_SIMULATIONCHOICE );
    }

    public void HealthTrainingMenu()
    {
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_HEALTHTRAINING);
    }

    public void EmergencyMenualMenu()
    {
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_EMERGENCYMENUAL);
    }
}