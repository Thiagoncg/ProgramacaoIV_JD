using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GpsLocation : MonoBehaviour
{
    [SerializeField] Text infoGps;
    [SerializeField] Text infoLatitude;
    [SerializeField] Text infoLongitude;
    private void Start() 
    {
        StartCoroutine(GpsLocalization());
    }

    IEnumerator GpsLocalization()
    {
        //Verifica se tem GPS no celular;
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("N Passou");
            infoGps.text = ("N passou");
            yield break;
        }
        

        //Inicia a localização
        Input.location.Start();

        //Aguarda os serviços ficarem prontos
        int maxTime = 20;
        while (Input.location.status ==  LocationServiceStatus.Initializing && maxTime > 0 )
        {
            yield return new WaitForSeconds(1);
            maxTime--;
        }

        //Se ocorreu a falha return erro Cancela o serviço 20 segundo da contagem
        if (maxTime < 1)
        {
            Debug.Log("Tempo esgotado");
            infoGps.text = ("Tempo esgotado");
            yield break;
        }

        if( Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("conexão terminada");
            infoGps.text = ("conexão terminada");
            yield break;
        }
        else
        {
            Debug.Log("Latitude location" + Input.location.lastData.latitude);
            Debug.Log("Longitude location" + Input.location.lastData.longitude);
            Debug.Log("Altitude Location" + Input.location.lastData.altitude);
            Debug.Log("Ancoragem location" + Input.location.lastData.verticalAccuracy);
            Debug.Log("Ancoragem location" + Input.location.lastData.horizontalAccuracy);

            infoGps.text = ("Latitude location" + Input.location.lastData.latitude).ToString();
            infoLatitude.text = ("Longitude location" + Input.location.lastData.longitude).ToString();;
            infoLongitude.text = (" Altitude Location" + Input.location.lastData.altitude).ToString();;
            infoGps.text = ("Ancoragem location" + Input.location.lastData.verticalAccuracy).ToString();;
            infoGps.text = ("Ancoragem location" + Input.location.lastData.horizontalAccuracy).ToString();;
        }


    }
}
