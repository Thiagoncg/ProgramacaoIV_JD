using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAnalogic : MonoBehaviour
{

    private Touch touchDevice;
    // Start is called before the first frame update
    void Start()
    {
        touchDevice = new Touch { fingerId = -1 };
    }

    void Update()
    {
        if (Input.touchCount > 0) // Se for > que 0 teve um toque na tela
        {
            for (int i = 0; i < Input.touchCount; i++) // Armazena um vetor de toques na tela percorrendo todos os toques
            {
                Debug.Log("vc clicou aqui com : " + i + " dedos aqui !");
                Debug.Log(("Valor do eixo x:" + Input.GetTouch(i).position.x)); // posição do click
                Debug.Log(("Valor do eixo y:" + Input.GetTouch(i).position.y)); // posição do click

                Debug.Log(Screen.width / 2); //Tamanho da terla / 2 no eixo x
                Debug.Log(Screen.height / 2); // Tamanho da tela /2 no eixo y

                 if (Input.GetTouch(i).position.x < Screen.width / 2 && Input.GetTouch(i).position.y < Screen.height / 2)
                 {
                    Debug.Log("Vc clicou no Quadrante inferior esquerdo");
                 }
                 else
                 {
                    Debug.Log("Vc clicou fora do quadrante inferior esquerdo");
                 }

            }
        }
    }
}
