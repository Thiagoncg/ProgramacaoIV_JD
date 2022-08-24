using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class analogic : MonoBehaviour
{
    private Touch touchDevice; // responsável pelo toque na tela
    private Vector2 startPos;
    public Transform background;
    public float radius = 150.0f;
    public Transform Player;
    public float speedPlayer = 0.2f;
    void Start()
    {
        touchDevice = new Touch { fingerId = -1 }; // o toque vai inicializar com um id

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0) // verifica se tem toque na tela
        {
            for (int i = 0; i < Input.touchCount; i++) // percorre por todos os inputs toques
            {
                if (touchDevice.fingerId == -1) // verifica se a variavel touch foi atribuida
                {
                    // verifica em que quadrante esta o toque na tela
                    if (Input.GetTouch(i).position.x < Screen.width / 2 && Input.GetTouch(i).position.y < Screen.height / 2)
                    {
                        touchDevice = Input.GetTouch(i);
                        startPos = touchDevice.position;
                        background.position = startPos;
                    }
                }
                else
                {
                    if (Input.GetTouch(i).fingerId == touchDevice.fingerId) // verifica a atualização do toque na tela
                    {
                        touchDevice = Input.GetTouch(i);
                    }
                }
            }

            if (touchDevice.fingerId != -1) // verifica se o toque foi cancela ou terminado. se isso ocorreu tudo deve ser zerado
            {
                if(touchDevice.phase == TouchPhase.Canceled || touchDevice.phase == TouchPhase.Ended) 
                {
                    touchDevice = new Touch { fingerId = -1 };
                }
                else// se não foi cancelado movimentamos o player
                {
                    Vector2 distance = touchDevice.position - startPos;

                    transform.position = startPos + Vector2.ClampMagnitude(distance, radius); // cria uma barreira do analogico determinado pelo radiuns

                    Player.position += (Vector3)distance * speedPlayer * Time.deltaTime; // movimenta o player de acordo com a velocidade

                    Player.up = Player.position + (Vector3)distance;
                }
            }
        }
        // if (touchDevice.fingerId == -1)
        // {
        //     touchDevice.position = Vector2.MoveTowards(transform.position, startPos, 70);
        // }
    }
}
