using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

    public GameObject LiverGame;

	void OnTriggerEnter(Collider _Other)
    {
        if( _Other.CompareTag("GoodFood") )
        {
            LiverGame.GetComponent<LiverGame>().ChangeEye("GoodFood");
            Destroy(_Other.gameObject);
        }
        else if( _Other.CompareTag("BadFood") )
        {
            // 좀더 효과 추가
            LiverGame.GetComponent<LiverGame>().MinusHP();
            LiverGame.GetComponent<LiverGame>().ChangeEye("BadFood");
            Destroy(_Other.gameObject);
        }
    }
}