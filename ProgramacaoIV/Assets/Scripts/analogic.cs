using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class analogic : MonoBehaviour
{
    private Touch touchDevice;
    private Vector2 startPos;
    public Transform background;
    public float radius = 150.0f;
    public Transform Player;
    public float speedPlayer = 0.2f;
    void Start()
    {
        touchDevice = new Touch { fingerId = -1 };

    }

    // Update is called once per frame
    void Update()
    {
        startPos = background.position;

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (touchDevice.fingerId == -1)
                {
                    if (Input.GetTouch(i).position.x < Screen.width / 2 && Input.GetTouch(i).position.y < Screen.height / 2)
                    {
                        touchDevice = Input.GetTouch(i);
                        startPos = touchDevice.position;
                        background.position = startPos;
                    }
                }
                else
                {
                    if (Input.GetTouch(i).fingerId == touchDevice.fingerId)
                    {
                        touchDevice = Input.GetTouch(i);
                    }
                }
            }

            if (touchDevice.fingerId != -1)
            {
                if(touchDevice.phase == TouchPhase.Canceled || touchDevice.phase == TouchPhase.Ended) 
                {
                    touchDevice = new Touch { fingerId = -1 };
                }
                else
                {
                    Vector2 distance = touchDevice.position - startPos;

                    transform.position = startPos + Vector2.ClampMagnitude(distance, radius);

                    Player.position += (Vector3)distance * speedPlayer * Time.deltaTime;

                    Player.up = Player.position + (Vector3)distance;
                }
            }
        }

        if (touchDevice.fingerId == -1)
        {
            touchDevice.position = Vector2.MoveTowards(transform.position, startPos, 70);
        }
    }
}
