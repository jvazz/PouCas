using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comida : MonoBehaviour
{
    public Text qtdMacaTxt, qtdWaffleTxt, qtdMacarraoTxt, qtdChurrascoTxt;
    int precoMaca = 100;
    int precoWaffle = 200;
    int precoMacarrao = 500;
    int precoChurrasco = 1000;
    public GameObject churrascoInterrogacao, churrascoImagem;

    public void Comprar(int produto)
    {
        if(produto == 1)
        {
            if(PlayerPrefs.GetInt("moedasKey") >= precoMaca)
            {
                PlayerPrefs.SetInt("macasKey", PlayerPrefs.GetInt("macasKey") + 1);
                PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") - precoMaca);
            }
        }
        if(produto == 2)
        {
            if(PlayerPrefs.GetInt("moedasKey") >= precoWaffle)
            {
                PlayerPrefs.SetInt("waffleKey", PlayerPrefs.GetInt("waffleKey") + 1);
                PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") - precoWaffle);
            }
        }
        if(produto == 3)
        {
            if(PlayerPrefs.GetInt("moedasKey") >= precoMacarrao)
            {
                PlayerPrefs.SetInt("macarraoKey", PlayerPrefs.GetInt("macarraoKey") + 1);
                PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") - precoMacarrao);
            }
        }
        if(produto == 4)
        {
            if(PlayerPrefs.GetInt("moedasKey") >= precoChurrasco)
            {
                PlayerPrefs.SetInt("churrascoKey", PlayerPrefs.GetInt("churrascoKey") + 1);
                PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") - precoChurrasco);
            }
        }
    }

    public void AtualizarQuantidade()
    {
        qtdMacaTxt.text = PlayerPrefs.GetInt("macasKey").ToString();
        qtdWaffleTxt.text = PlayerPrefs.GetInt("waffleKey").ToString();
        qtdMacarraoTxt.text = PlayerPrefs.GetInt("macarraoKey").ToString();
        qtdChurrascoTxt.text = PlayerPrefs.GetInt("churrascoKey").ToString();

        if(PlayerPrefs.GetInt("churrascoKey") > 0)
        {
            churrascoInterrogacao.SetActive(false);
            churrascoImagem.SetActive(true);
        }else
        {
            churrascoInterrogacao.SetActive(true);
            churrascoImagem.SetActive(false);
        }
    }

    public void Alimentar(int produto)
    {
        if(PlayerPrefs.GetFloat("fomeKey") <  0.99f)
        {
            if(produto == 1)
            {
                if(PlayerPrefs.GetInt("macasKey") > 0)
                {
                    PlayerPrefs.SetInt("macasKey", PlayerPrefs.GetInt("macasKey") - 1);
                    if(PlayerPrefs.GetFloat("fomeKey") > 0.75f)
                    {
                        PlayerPrefs.SetFloat("fomeKey", PlayerPrefs.GetFloat("fomeKey") + (1 - PlayerPrefs.GetFloat("fomeKey")));
                    }else
                    {
                        PlayerPrefs.SetFloat("fomeKey", PlayerPrefs.GetFloat("fomeKey") + 0.25f);
                    }
                }
            }
            if(produto == 2)
            {
                if(PlayerPrefs.GetInt("waffleKey") > 0)
                {
                    PlayerPrefs.SetInt("waffleKey", PlayerPrefs.GetInt("waffleKey") - 1);
                    if(PlayerPrefs.GetFloat("fomeKey") > 0.5f)
                    {
                        PlayerPrefs.SetFloat("fomeKey", PlayerPrefs.GetFloat("fomeKey") + (1 - PlayerPrefs.GetFloat("fomeKey")));
                    }else
                    {
                        PlayerPrefs.SetFloat("fomeKey", PlayerPrefs.GetFloat("fomeKey") + 0.5f);
                    }
                }
            }
            if(produto == 3)
            {
                if(PlayerPrefs.GetInt("macarraoKey") > 0)
                {
                    PlayerPrefs.SetInt("macarraoKey", PlayerPrefs.GetInt("macarraoKey") - 1);
                    if(PlayerPrefs.GetFloat("fomeKey") > 0.25f)
                    {
                        PlayerPrefs.SetFloat("fomeKey", PlayerPrefs.GetFloat("fomeKey") + (1 - PlayerPrefs.GetFloat("fomeKey")));
                    }else
                    {
                        PlayerPrefs.SetFloat("fomeKey", PlayerPrefs.GetFloat("fomeKey") + 0.75f);
                    }
                }
            }
            if(produto == 4)
            {
                if(PlayerPrefs.GetInt("churrascoKey") > 0)
                {
                    PlayerPrefs.SetInt("churrascoKey", PlayerPrefs.GetInt("churrascoKey") - 1);
                    PlayerPrefs.SetFloat("fomeKey", PlayerPrefs.GetFloat("fomeKey") + (1 - PlayerPrefs.GetFloat("fomeKey")));
                }
            }

            qtdMacaTxt.text = PlayerPrefs.GetInt("macasKey").ToString();
            qtdWaffleTxt.text = PlayerPrefs.GetInt("waffleKey").ToString();
            qtdMacarraoTxt.text = PlayerPrefs.GetInt("macarraoKey").ToString();
            qtdChurrascoTxt.text = PlayerPrefs.GetInt("churrascoKey").ToString();
            if(PlayerPrefs.GetInt("churrascoKey") > 0)
            {
                churrascoInterrogacao.SetActive(false);
                churrascoImagem.SetActive(true);
            }else
            {
                churrascoInterrogacao.SetActive(true);
                churrascoImagem.SetActive(false);
            }
        }
    }
}
