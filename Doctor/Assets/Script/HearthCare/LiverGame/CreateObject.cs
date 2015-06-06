using UnityEngine;
using System.Collections;

public class CreateObject : MonoBehaviour {

    public GameObject[] Food;
    public string GameName;
    public float CreateTime;
    public bool isTime;

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
        if (isTime)
        {
            CurrentTimeText = GameObject.Find("CurrentTime").GetComponent<UILabel>();
        }        
    }

	void Update ()
    {
        CurrentCreateTime += RealTime.deltaTime;
        CurrentTime += RealTime.deltaTime;

        if (isTime)
        {
            IntCurrentTime = (int)CurrentTime;
            CurrentTimeText.text = IntCurrentTime.ToString();

            if (1 <= CurrentTime / CurrentStage)
            {
                Speed -= 0.003f;
                CurrentStage += 10;
                CreateTime -= 0.1f;
            }

            if (30 <= CurrentTime)
            {
                BackGroundManager.getInstance().ChangeBackGround(BackGroundManager.SCENE_NUM.E_SUCCES, GameName + "Succes");
            }
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