using UnityEngine;
using System.Collections;

public class Succes : MonoBehaviour {

	private float Alpha;
	public float Speed;

	
	// Use this for initialization
	void Start () {
		Alpha = 1.0f;
		GetComponent<UISprite> ().alpha = Alpha;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<UISprite> ().alpha > 0.0f) {
			Alpha -= Speed * RealTime.deltaTime;
			GetComponent<UISprite> ().alpha = Alpha;
		} else{
            Debug.Log( "Succes" );
			BackGroundManager.getInstance().ChangeBackGround( BackGroundManager.SCENE_NUM.E_MAIN );
		}
	}
}