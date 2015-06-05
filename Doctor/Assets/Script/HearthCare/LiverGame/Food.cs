using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

    public float Speed;
    public GameObject Boom;

    private GameObject TempObj;

	// Update is called once per frame
	void Update () {
        transform.Translate(Speed, 0.0f, 0.0f);
	}

    public void DestroyFood()
    {
        TempObj = Instantiate(Boom);
        TempObj.GetComponent<BoomAnim>().CreatePos = transform.position;

        if( tag == "GoodFood" )
        {
            GameObject.Find("LiverGame(Clone)").GetComponent<LiverGame>().MinusHP();
        }

        Destroy(gameObject);
    }
}