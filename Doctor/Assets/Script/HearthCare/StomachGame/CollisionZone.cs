using UnityEngine;
using System.Collections;

public class CollisionZone : MonoBehaviour {

    public GameObject Game;    
	
    void OnTriggerEnter( Collider _Other )
    {
        Game.GetComponent<StomachGame>().CurrentFood = _Other.gameObject;
    }
}