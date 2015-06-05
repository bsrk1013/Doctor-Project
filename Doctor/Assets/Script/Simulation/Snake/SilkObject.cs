using UnityEngine;
using System.Collections;

public class SilkObject : DragAndDropObject {

    public GameObject Quiz;

    void Start()
    {
        Init();
    }

    void Update()
    {
        DragSense();
    }

    public override void DropEvent()
    {
        if ("UpSilk" == CollisionTag)
        {
            Quiz.GetComponent<SnakeQuiz>().UpSilk();
            gameObject.SetActive(false);
        } else if( "DownSilk" == CollisionTag)
        {
            Quiz.GetComponent<SnakeQuiz>().DownSilk();
            isCollision = false;
        }
    }
}