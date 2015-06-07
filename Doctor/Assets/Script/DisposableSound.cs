using UnityEngine;
using System.Collections;

public class FoodSound : MonoBehaviour {    

	// Update is called once per frame
	void Update ()
    {
	if(!GetComponent<AudioSource>().isPlaying)
    {
        Destroy(gameObject);
    }
	}
}