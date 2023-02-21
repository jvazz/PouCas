using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Estadio : MonoBehaviour
{
    public GameObject plano1GObj, plano2GObj, plano3GObj; 
    Image plano1Img, plano2Img, plano3Img; 
    public Color verde, branco;
    public Text precoIngressoTxt;
    int preco = 10000;
    int precoPlano1 = 0;
    int precoPlano2 = 100;
    int precoPlano3 = 1000;
    public GameObject fundoEstadio;
    public GameObject painelEstadio;
    bool estaEmJogo = false;
    public Text ingressosTxt, ingressos2Txt;
    public GameObject galoGanhouPanel;

    void Start()
    {
        estaEmJogo = false;
        plano1Img = plano1GObj.GetComponent<Image>();
        plano2Img = plano2GObj.GetComponent<Image>();
        plano3Img = plano3GObj.GetComponent<Image>();

        if(PlayerPrefs.GetInt("planoGaloNaVeiaKey") == 0)
        {
            plano1Img.color = verde;
            plano2Img.color = branco;
            plano3Img.color = branco;
            precoIngressoTxt.text = (preco * 0.9f).ToString();
        }
        if(PlayerPrefs.GetInt("planoGaloNaVeiaKey") == 1)
        {
            plano1Img.color = branco;
            plano2Img.color = verde;
            plano3Img.color = branco;
            precoIngressoTxt.text = (preco * 0.5f).ToString();
        }
        if(PlayerPrefs.GetInt("planoGaloNaVeiaKey") == 2)
        {
            plano1Img.color = branco;
            plano2Img.color = branco;
            plano3Img.color = verde;
            precoIngressoTxt.text = (preco * 0.2f).ToString();
        }

        InvokeRepeating("CobrarPlano", 10, 10);
    }

    void CobrarPlano()
    {
        if(PlayerPrefs.GetInt("planoGaloNaVeiaKey") == 0)
        {
            PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") - precoPlano1);
        }

        if(PlayerPrefs.GetInt("planoGaloNaVeiaKey") == 1)
        {
            if(PlayerPrefs.GetInt("moedasKey") >= precoPlano2)
            {
                PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") - precoPlano2);
            }else
            {
                PlayerPrefs.SetInt("planoGaloNaVeiaKey", 0);
                plano1Img.color = verde;
                plano2Img.color = branco;
                plano3Img.color = branco;
                precoIngressoTxt.text = (preco * 0.9f).ToString();
            }
        }

        if(PlayerPrefs.GetInt("planoGaloNaVeiaKey") == 2)
        {
            if(PlayerPrefs.GetInt("moedasKey") >= precoPlano3)
            {
                PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") - precoPlano3);
            }else
            {
                PlayerPrefs.SetInt("planoGaloNaVeiaKey", 0);
                plano1Img.color = verde;
                plano2Img.color = branco;
                plano3Img.color = branco;
                precoIngressoTxt.text = (preco * 0.9f).ToString();
            }
        }

    }

    public void Plano1()
    {
        PlayerPrefs.SetInt("planoGaloNaVeiaKey", 0);
        plano1Img.color = verde;
        plano2Img.color = branco;
        plano3Img.color = branco;
        precoIngressoTxt.text = (preco * 0.9f).ToString();
        CobrarPlano();
    }
    public void Plano2()
    {
        PlayerPrefs.SetInt("planoGaloNaVeiaKey", 1);
        plano1Img.color = branco;
        plano2Img.color = verde;
        plano3Img.color = branco;
        precoIngressoTxt.text = (preco * 0.5f).ToString();
        CobrarPlano();
    }
    public void Plano3()
    {
        PlayerPrefs.SetInt("planoGaloNaVeiaKey", 2);
        plano1Img.color = branco;
        plano2Img.color = branco;
        plano3Img.color = verde;
        precoIngressoTxt.text = (preco * 0.2f).ToString();
        CobrarPlano();
    }

    public void ComprarIngresso()
    {
        AtualizarIngressos();

        if(PlayerPrefs.GetInt("planoGaloNaVeiaKey") == 0)
        {
            if(PlayerPrefs.GetInt("moedasKey") >= (preco / 100 * 90))
            {
                PlayerPrefs.SetInt("ingressosKey", PlayerPrefs.GetInt("ingressosKey") + 1);
                PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") - (preco / 100 * 90));
            }
        }
        if(PlayerPrefs.GetInt("planoGaloNaVeiaKey") == 1)
        {
            if(PlayerPrefs.GetInt("moedasKey") >= (preco / 100 * 90))
            {
                PlayerPrefs.SetInt("ingressosKey", PlayerPrefs.GetInt("ingressosKey") + 1);
                PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") - (preco / 100 * 50));
            }
        }
        if(PlayerPrefs.GetInt("planoGaloNaVeiaKey") == 2)
        {
            if(PlayerPrefs.GetInt("moedasKey") >= (preco / 100 * 90))
            {
                PlayerPrefs.SetInt("ingressosKey", PlayerPrefs.GetInt("ingressosKey") + 1);
                PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") - (preco / 100 * 20));
            }
        }
    }

    public void EntrarNoEstadio()
    {
        if(PlayerPrefs.GetInt("ingressosKey") > 0)
        {
            painelEstadio.SetActive(false);
            fundoEstadio.SetActive(true);
            estaEmJogo = true;
            PlayerPrefs.SetInt("ingressosKey", PlayerPrefs.GetInt("ingressosKey") - 1);
        }
    }

    void FixedUpdate()
    {
        if(estaEmJogo)
        {
            if(PlayerPrefs.GetFloat("felicidadeKey") <= 0.999)
            {
                PlayerPrefs.SetFloat("felicidadeKey", PlayerPrefs.GetFloat("felicidadeKey") + 0.001f);
            }

            if(PlayerPrefs.GetFloat("felicidadeKey") > 0.999)
            {
                SairDoEstadio();
            }
        }
    }

    public void SairDoEstadio()
    {
        estaEmJogo = false;
        fundoEstadio.SetActive(false);
        galoGanhouPanel.SetActive(true);
        Invoke("EsconderPainel", 1f);
    }

    public void AtualizarIngressos()
    {
        ingressosTxt.text = PlayerPrefs.GetInt("ingressosKey").ToString();
        ingressos2Txt.text = PlayerPrefs.GetInt("ingressosKey").ToString();
    }

    void EsconderPainel()
    {
        galoGanhouPanel.SetActive(false);
    }
}
