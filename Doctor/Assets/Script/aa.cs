using UnityEngine;
using System.Collections;

public class aa : MonoBehaviour {

    public bool isCollision = false;
    private bool isClick = false;
    private int Count;
    private Vector3 DefaultPos;

    void Start()
    {
        isClick = false;
        DefaultPos = new Vector3( 1.5f, 0.1f );
    }

    void Update()
    {
        Count = Input.touchCount;

        if (0 == Count)
        {
            isClick = false;
        } else
        {
            isClick = true;
        }

        if(Input.GetMouseButtonUp(0))
        {
            isClick = false;
        }
        else if (Input.GetMouseButton(0))
        {
            isClick = true;
        }

        if (!isCollision && !isClick)
        {
            transform.position = DefaultPos;
        }
        else if (isCollision && !isClick)
        {
            Destroy( gameObject );
        }
    }

    void OnTriggerEnter(Collider _Other)
    {
        if ("SilkButton" == _Other.tag)
        {
            isCollision = true;
        }
    }

    void OnTriggerExit(Collider _Other)
    {
        if ("SilkButton" == _Other.tag)
        {
            isCollision = false;
        }
    }
}