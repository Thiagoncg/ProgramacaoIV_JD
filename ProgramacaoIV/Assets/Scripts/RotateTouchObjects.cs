using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateTouchObjects : MonoBehaviour
{
    private Vector2 initialPosition;
    [SerializeField] float SwipeMinY;
    [SerializeField] float SwipeMinX;
    [SerializeField] Text infoSwap;
    void Update()
    {
      RotateObject();
      Gestures();
    }

    private void RotateObject()
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

    private void Gestures()
    {
        if(Input.touchCount > 0)
        {
            Touch touchInput = Input.touches[0];

            if (touchInput.phase == TouchPhase.Began)
            {
                initialPosition = touchInput.position;                
            }
            else if(touchInput.phase == TouchPhase.Ended)
            {
                float swipeVertical = (new Vector3(0,touchInput.position.y, 0) - new Vector3(0, initialPosition.y, 0)).magnitude;
                if(swipeVertical > SwipeMinY)
                {
                    float u = Mathf.Sign(touchInput.position.y - initialPosition.y);
                    if (u > 0)
                    {
                        Debug.Log("move to Up");
                        infoSwap.text = "Move to Up";
                    }
                    if (u < 0)
                    {
                        Debug.Log("move to down");
                        infoSwap.text = "Move to down";
                    }
                }


                float swipeHorizontal = (new Vector3(touchInput.position.x, 0, 0) - new Vector3(initialPosition.x, 0, 0)).magnitude;
                if(swipeHorizontal > SwipeMinX)
                {
                    float u = Mathf.Sign(touchInput.position.x - initialPosition.x);
                    if (u > 0)
                    {
                        Debug.Log("move to Right");
                        infoSwap.text = "Move to Right";
                    }
                    if (u < 0)
                    {
                        Debug.Log("move to Left");
                        infoSwap.text = "move to Left";
                    }
                }
            }
        }
    }
}
