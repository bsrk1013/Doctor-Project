using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
    
    public GameObject CardBack;

    private float LittleTime;
    private GameObject Game;
    private float CurrentTime;
    private bool isStart;

	// Use this for initialization
	void Start () {
        LittleTime = 3;
        CurrentTime = 0;
        CardBack.SetActive(false);
        isStart = true;
        Game = GameObject.Find("DementiaGame(Clone)");
	}
	
	// Update is called once per frame
	void Update () {

        StartCard();
	}

    public void SelectCard()
    {
        if (2 <= Game.GetComponent<DementiaGame>().CountCard)
        {
            return;
        }

        CardBack.SetActive(false);
        Game.GetComponent<DementiaGame>().SelectCard(gameObject);
    }

    private void StartCard()
    {
        if (isStart)
        {
            CurrentTime += RealTime.deltaTime;

            if (LittleTime <= CurrentTime)
            {
                CardBack.SetActive(true);
                isStart = false;
                CurrentTime = 0;
            }
        }
    }
}