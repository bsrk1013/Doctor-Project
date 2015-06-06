using UnityEngine;
using System.Collections;

public class BoomAnim : MonoBehaviour
{
    public Vector3 CreatePos;

    private float DestroyTime;
    private UISprite Sprite;
    private int Turn;
    
    void Start()
    {
        Sprite = GetComponent<UISprite>();
        transform.position = CreatePos;
        Turn = 0;
    }

    void Update()
    {
        DestroyTime += RealTime.deltaTime;

        if (0.1f < DestroyTime && 0 == Turn)
        {
            Debug.Log(transform.position);
            ++Turn;
            Sprite.spriteName = "Boom0";
        }
        else if (0.2f < DestroyTime && 1 == Turn)
        {
            ++Turn;
            Sprite.spriteName = "Boom1";
        }
        else if (0.3f < DestroyTime && 2 == Turn)
        {            
            Destroy(gameObject);
        }
    }
}