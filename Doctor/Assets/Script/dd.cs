using UnityEngine;
using System.Collections;

public class dd : MonoBehaviour {

    void OnTriggerEnter( Collider _Other )
    {
        if( "Silk" == _Other.tag )
        {            
            _Other.gameObject.GetComponent<aa>().isCollision = true;
            Debug.Log(_Other.gameObject.GetComponent<aa>().isCollision);
        }
    }

    void OnTriggerExit( Collider _Other )
    {
        if ("Silk" == _Other.tag)
        {
            _Other.gameObject.GetComponent<aa>().isCollision = false;
            Debug.Log(_Other.gameObject.GetComponent<aa>().isCollision);
        }
    }
}