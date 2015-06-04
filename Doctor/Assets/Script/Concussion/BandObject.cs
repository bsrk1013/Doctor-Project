using UnityEngine;
using System.Collections;

public class BandObject : DragAndDropObject {

    public GameObject Quiz;

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        DragSense();
	}

    public override void DropEvent()
    {
        Debug.Log(CollisionTag);
        if( "Head" == CollisionTag )
        {            
            Quiz.GetComponent<ConcussionQuiz>().HeadZoneButton();
            gameObject.SetActive(false);
        }
    }
}