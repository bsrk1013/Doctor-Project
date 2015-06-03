using UnityEngine;
using System.Collections;

public class Silk : MonoBehaviour {

    public Vector3 DefaultPos;

	void Update()
    {        
    }

    public void AutoDestroy()
    {
        Destroy( this );
    }
}