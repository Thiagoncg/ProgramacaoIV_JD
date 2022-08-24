using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acelerometre : MonoBehaviour
{
    
    [SerializeField] private float speed  = 10.0f;

    void Update()
    {
        IntroductionAcer();
        //MoveObject();
    }

    private void IntroductionAcer()
    {
       transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
        Debug.Log("O valor de X é: " + Input.acceleration.x);
        Debug.Log("O valor de Y é: " + Input.acceleration.y);
        Debug.Log("O valor de Z é: " + Input.acceleration.z);
    } 

    private void MoveObject()
    {
        Vector3 direction = Vector3.zero;


        // Brinque com estes valores para entender a orientação o dispositivo
        direction.x = -Input.acceleration.y;
        direction.z = Input.acceleration.x;

        if(direction.sqrMagnitude > 1)
        {
            direction.Normalize();
        }

        direction *= Time.deltaTime;

        transform.Translate (direction * speed);
    }
}
