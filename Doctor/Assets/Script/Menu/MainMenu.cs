using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

	public void SimulationChoiceMenu()
    {
        BackGroundManager.getInstance().ChangeBackGround( BackGroundManager.SCENE_NUM.E_SIMULATIONCHOICE );
    }

    public void HealthTrainingMenu()
    {
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_HEALTHCARE);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}