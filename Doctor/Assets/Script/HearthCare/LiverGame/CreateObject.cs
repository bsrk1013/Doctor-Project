using UnityEngine;
using System.Collections;

public class CreateObject : MonoBehaviour {

    public GameObject[] Food;    
    public float CreateTime;

    private float CurrentTime;
    private float CurrentCreateTime;
    private int CurrentStage;
    private int IntCurrentTime;
    private float Speed;
    private GameObject TempObj;
    private UILabel CurrentTimeText;

    void Start()
    {
        CurrentTime = 0;
        Speed = -0.01f;
        CurrentStage = 10;
        CurrentTimeText = GameObject.Find("CurrentTime").GetComponent<UILabel>();
    }

	void Update ()
    {
        CurrentCreateTime += RealTime.deltaTime;
        CurrentTime += RealTime.deltaTime;
        IntCurrentTime = (int)CurrentTime;
        CurrentTimeText.text = IntCurrentTime.ToString();

        if (30 <= CurrentTime)
        {
            BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_SUCCES);
        }

        if (1 <= CurrentTime / CurrentStage)
        {
            Debug.Log("HERE");
            Speed -= 0.003f;
            CurrentStage += 10;
            CreateTime -= 0.1f;
        }

        if (CreateTime < CurrentCreateTime)
        {
            TempObj = Instantiate(Food[Random.Range(0, Food.Length)]);                        
            TempObj.transform.parent = transform;
            TempObj.transform.position = transform.position;
            TempObj.transform.localScale = new Vector3( 1.0f, 1.0f, 1.0f );
            TempObj.GetComponent<Food>().Speed = Speed;
            CurrentCreateTime = 0;
        }
	}
}