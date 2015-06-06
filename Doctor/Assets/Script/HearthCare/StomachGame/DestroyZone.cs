using UnityEngine;
using System.Collections;

public class DestroyZone : MonoBehaviour {

	void OnTriggerEnter( Collider _Other )
    {
        Destroy(_Other.gameObject);
    }
}