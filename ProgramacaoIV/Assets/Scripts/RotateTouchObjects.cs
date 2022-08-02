using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTouchObjects : MonoBehaviour
{
    void Update()
    {
        //Verifica o toque na tela
        if (Input.touchCount > 0)
        {
            //MSG de toque, verificar adicionando todos os dedos
            Debug.Log("Karaka tocou na tela");

            // Armazenar em uma variavel todos os toques na tela, nestre caso pego o primeiro [0];
            Touch primaryTouch = Input.GetTouch(0);

            //Verifica o movimento do dedo (tocou, estagio, moveu outro estágio e assimpor diante)
            if (primaryTouch.phase == TouchPhase.Moved)
            {
                //transforma a direção da rotação
                Vector2 directionRotation = new Vector2(primaryTouch.deltaPosition.y, primaryTouch.deltaPosition.x * -1);

                //A rotação do objeto é em relação ao espaço.Referente a cena do objeto
                transform.Rotate(directionRotation * 5 * Time.deltaTime, Space.World);
            }
        }        
    }
}
