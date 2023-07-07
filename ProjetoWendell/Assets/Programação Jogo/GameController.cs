using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text vidaTxt;

    public static GameController controle;
    // Start is called before the first frame update
    void Start()
    {
        controle = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void vidaTexto(int valor)
    {
        vidaTxt.text = valor.ToString() + "X";
    }
}
