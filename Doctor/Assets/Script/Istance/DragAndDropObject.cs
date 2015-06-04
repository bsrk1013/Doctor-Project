using UnityEngine;
using System.Collections;

public abstract class DragAndDropObject : MonoBehaviour {

    public Vector3 DefaultPos;

    protected bool isCollision = false;    
    protected bool isClick = false;   // PC용
    protected bool isDrop = false;
    protected string CollisionTag;
    protected int Count;
    protected UIDragObject Drag;

    protected void Init()
    {
        Debug.Log( "pos : " + transform.position );
        isClick = false;
    }

    protected void DragSense()
    {
        Count = Input.touchCount;

        if (0 == Count)
        {
            isClick = false;
        }
        else
        {
            isClick = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isClick = false;
        }
        else if (Input.GetMouseButton(0))
        {
            isClick = true;
        }   // PC용

        if (!isCollision && !isClick)
        {
            transform.position = DefaultPos;
        }
        else if (isCollision && !isClick)
        {
            DropEvent();
        }
    }    

    protected void OnTriggerEnter(Collider _Other)
    {
            CollisionTag = _Other.tag;
            isCollision = true;
    }

    protected void OnTriggerExit(Collider _Other)
    {
        isCollision = false;
    }

    public abstract void DropEvent();
}