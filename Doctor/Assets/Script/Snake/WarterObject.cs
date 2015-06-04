using UnityEngine;
using System.Collections;

public class WarterObject : DragAndDropObject {

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
        if( "Warter" == CollisionTag )
        {
            Quiz.GetComponent<SnakeQuiz>().WarterDrop();
            gameObject.SetActive(false);
        }
    }
}