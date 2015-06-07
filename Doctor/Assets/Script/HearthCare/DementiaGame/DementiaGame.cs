using UnityEngine;
using System.Collections;

public class DementiaGame : MonoBehaviour {

    public GameObject[] RandomCard;
    public GameObject CardClickSound;
    public int CountCard;

    private GameObject[] AllCard = new GameObject[12];    
    private GameObject[] SelectedCard = new GameObject[2];
    private int[] OverlapCardCount = new int[12];
    private int CountClearCard;
    private float CurrentTime;

	void Start ()
    {
        CurrentTime = 0;
        CountClearCard = 0;
        for (int i = 0; OverlapCardCount.Length > i; ++i)
        {
            OverlapCardCount[i] = 0;
        }

        InitCard();
	}
	
	// Update is called once per frame
	void Update () {
        CompareCard();

        if (RandomCard.Length == CountClearCard)
        {
            ClearGame();
        }
	}

    public void SelectCard(GameObject _Slect)
    {
        Instantiate(CardClickSound);
        SelectedCard[CountCard] = _Slect;
        ++CountCard;
    }

    private void ClearGame()
    {
        BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_SUCCES2, "DementiaGameSucces");
    }

    private void CompareCard()
    {
        if (2 != CountCard)
        {
            return;
        }

        CurrentTime += RealTime.deltaTime;

        if (1 <= CurrentTime)
        {
            if (SelectedCard[0].ToString() == SelectedCard[1].ToString()
                && SelectedCard[0].transform.parent.gameObject.ToString() != SelectedCard[1].transform.parent.gameObject.ToString())
            {
                SelectedCard[0].SetActive(false);
                SelectedCard[1].SetActive(false);
                ++CountClearCard;
            }
            else
            {
                SelectedCard[0].transform.GetChild(0).gameObject.SetActive(true);
                SelectedCard[1].transform.GetChild(0).gameObject.SetActive(true);
            }

            CurrentTime = 0;
            CountCard = 0;
        }
    }

    private void InitCard()
    {
        for (int a = 0; AllCard.Length > a; ++a)
        {
            int RandomNum = Random.Range(0, 2);
            while(true)
            {
                if(2 <= OverlapCardCount[RandomNum])
                {
                    RandomNum = Random.Range(0, RandomCard.Length);
                }
                else
                {
                    break;
                }
            }

            AllCard[a] = Instantiate(RandomCard[RandomNum]);
            OverlapCardCount[RandomNum] += 1;
            AllCard[a].transform.parent = GameObject.Find("Card" + a).transform;
            AllCard[a].transform.localPosition = new Vector3(0.0f, 0.0f);
            AllCard[a].transform.localScale = new Vector2(1.0f, 1.0f);            
        }
    }
}