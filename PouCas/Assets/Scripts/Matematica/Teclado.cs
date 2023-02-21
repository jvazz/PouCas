using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teclado : MonoBehaviour
{
    public Text tecladoTxt;

    // Start is called before the first frame update
    void Start()
    {
        tecladoTxt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pronto()
    {
        if(tecladoTxt.text != "")
        {
            MatematicaScript.resposta = float.Parse(tecladoTxt.text);
            MatematicaScript.podePerguntar = true;
            tecladoTxt.text = "";
        }
    }
    public void Ponto()
    {
        if(!tecladoTxt.text.Contains(","))
        {
            tecladoTxt.text = tecladoTxt.text + ",";
        }
    }
    public void Deletar()
    {
        tecladoTxt.text = "";
    }

    public void Numero1()
    {
        tecladoTxt.text = tecladoTxt.text + "1";
    }
    public void Numero2()
    {
        tecladoTxt.text = tecladoTxt.text + "2";
    }
    public void Numero3()
    {
        tecladoTxt.text = tecladoTxt.text + "3";
    }
    public void Numero4()
    {
        tecladoTxt.text = tecladoTxt.text + "4";
    }
    public void Numero5()
    {
        tecladoTxt.text = tecladoTxt.text + "5";
    }
    public void Numero6()
    {
        tecladoTxt.text = tecladoTxt.text + "6";
    }
    public void Numero7()
    {
        tecladoTxt.text = tecladoTxt.text + "7";
    }
    public void Numero8()
    {
        tecladoTxt.text = tecladoTxt.text + "8";
    }
    public void Numero9()
    {
        tecladoTxt.text = tecladoTxt.text + "9";
    }
    public void Numero0()
    {
        tecladoTxt.text = tecladoTxt.text + "0";
    }
}
