using UnityEngine;
using System.Collections;

public class MenualChoice : MonoBehaviour {

    public GameObject ButtonSound;

	public void BackButton()
    {
        Instantiate(ButtonSound);
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_MAIN);
    }

    public void DiabetesMellitusButton()
    {
        Instantiate(ButtonSound);
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_DISABETESMELITUSMENUAL);
    }

    public void CencerButton()
    {
        Instantiate(ButtonSound);
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_CENCERMENUAL);
    }

    public void HypertentionButton()
    {
        Instantiate(ButtonSound);
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_HYPERTENSIONMENUAL);
    }

    public void CardiovascularDiseaseButton()
    {
        Instantiate(ButtonSound);
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_CARDIOVASCULARDISEASEMENUAL);
    }
}