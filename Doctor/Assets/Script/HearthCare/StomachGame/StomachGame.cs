using UnityEngine;
using System.Collections;

public class StomachGame : MonoBehaviour {

    public GameObject CurrentFood;
    public GameObject GaugeObj;
    public GameObject Hand0;
    public GameObject Hand1;
    
    private float CurrentTime;
    private float GaugePercent;
    private bool isAnim;
    private int HP;

    void Start()
    {
        HP = 3;
        isAnim = false;
        CurrentTime = 0;
        GaugePercent = 0.0f;
    }

    void Update()
    {
        PlayHandAnim();

        if (0 == HP)
        {
            EndGame();
        }

        if( 1.0f <= GaugePercent )
        {
            ClearGame();
        }
    }

    private void EndGame()
    {
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_FAIL, "StomachGameSucces");
    }

    private void ClearGame()
    {
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_SUCCES, "StomachGameSucces");
    }

    private void PlayHandAnim()
    {
        if (isAnim)
        {
            CurrentTime += RealTime.deltaTime;

            if (0.3f < CurrentTime)
            {
                Hand0.SetActive(true);
                Hand1.SetActive(false);
                isAnim = false;
                CurrentTime = 0;
            }
        }
    }

    private void MinusHP()
    {
        GameObject.Find("Heart" + HP).SetActive(false);
        --HP;
    }

    private void Gauge()
    {
        GaugePercent += 0.1f;
        GaugeObj.GetComponent<UISlider>().value = GaugePercent;
    }

    public void CheckFood()
    {
        if (null == CurrentFood)
        {
            return;
        }

        if ("GoodFood" == CurrentFood.tag)
        {            
            Destroy(CurrentFood);
            // 게이지 상승 함수 추가해야함
            Gauge();
        }
        else if ("BadFood" == CurrentFood.tag)
        {
            Destroy(CurrentFood);
            MinusHP();
        }
    }

    public void ChangeHand()
    {
        Hand0.SetActive(false);
        Hand1.SetActive(true);
        isAnim = true;
    }


}