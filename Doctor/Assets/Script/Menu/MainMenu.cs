using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public GameObject ButtonSound;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

	public void SimulationChoiceMenu()
    {
        Instantiate(ButtonSound);
        BackGroundManager.getInstance().ChangeBackGround( BackGroundManager.SCENE_NUM.E_SIMULATIONCHOICE );
    }

    public void HealthTrainingMenu()
    {
        Instantiate(ButtonSound);
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_HEALTHCARECHOICE);
    }

    public void MenualButton()
    {
        Instantiate(ButtonSound);
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_MENUALCHOICE);
    }

    public void QuitButton()
    {
        Instantiate(ButtonSound);
        Application.Quit();
    }
}