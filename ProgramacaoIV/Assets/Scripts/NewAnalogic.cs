using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAnalogic : MonoBehaviour
{
    private Touch touchDevice;
    void Start()
    {
        //Toque na tela recebe um ID = Primeiro toque
        touchDevice = new Touch { fingerId = -1 };
    }

    void Update()
    {
        //Se eu toquei na tela
        if (Input.touchCount > 0)
        {
            //Contador de toques percorre o screen da tela
            for (int i = 0; i < Input.touchCount; i++)
            {
                //contagem de toques percorrido pelo vetor
                Debug.Log("Você clicou com :" + i + "dedos aqui");

                //Identifica cliques no eixo x e y
                Debug.Log("Valor no eixo x:" + Input.GetTouch(i).position.x);
                Debug.Log("Valor no eixo y:" + Input.GetTouch(i).position.y);

                Debug.Log("Tela dividido por 2 " + Screen.width / 2);
                Debug.Log("Tela dividido por 2 " + Screen.height / 2);

                if (Input.GetTouch(i).position.x < Screen.width / 2 && Input.GetTouch(i).position.y < Screen.height / 2)
                {
                    Debug.Log("Cl");
                }
                else
                {
                    
                }




            }
        }
    }
}
