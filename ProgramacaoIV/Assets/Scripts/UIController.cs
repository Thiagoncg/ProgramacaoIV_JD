using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text textDisplay;

    void Start()
    {
        textDisplay.text = "Thiago Garcia";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextoBotao()
    {
        textDisplay.text = "Thiago Garcia Clicado";
    }
}
