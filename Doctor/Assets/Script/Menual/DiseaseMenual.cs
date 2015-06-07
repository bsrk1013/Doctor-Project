using UnityEngine;
using System.Collections;

public class DiseaseMenual : MonoBehaviour
{
    public GameObject NextSound;
    public int MaixmumCount;
    public string DiseaseName;

    private int CurrencCount;

	// Use this for initialization
	void Start () {
	    CurrencCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if( CurrencCount >= MaixmumCount )
        {
            BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_MENUALCHOICE);
        }
	}

    public void Click()
    {
        ++CurrencCount;

        if (CurrencCount >= MaixmumCount)
        {
            return;
        }
        Instantiate(NextSound);
        gameObject.GetComponent<UISprite>().spriteName = DiseaseName + CurrencCount;        
    }
}