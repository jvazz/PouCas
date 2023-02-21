using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Investimentos : MonoBehaviour
{
    public GameObject investimento1GObj, investimento2GObj, investimento3GObj, investimento4GObj; 
    Image investimento1Img, investimento2Img, investimento3Img, investimento4Img; 
    public Color verde, branco;
    int perder = 0;
    float dinheiro = 0;

    void Start()
    {
        dinheiro = PlayerPrefs.GetInt("moedasKey");
        investimento1Img = investimento1GObj.GetComponent<Image>();
        investimento2Img = investimento2GObj.GetComponent<Image>();
        investimento3Img = investimento3GObj.GetComponent<Image>();
        investimento4Img = investimento4GObj.GetComponent<Image>();
        perder = 0;
        InvokeRepeating("Render", 60f, 60f);

        if(PlayerPrefs.GetInt("investimentoKey") == 0)
        {
            investimento1Img.color = verde;
            investimento2Img.color = branco;
            investimento3Img.color = branco;
            investimento4Img.color = branco;
        }
        if(PlayerPrefs.GetInt("investimentoKey") == 1)
        {
            investimento1Img.color = branco;
            investimento2Img.color = verde;
            investimento3Img.color = branco;
            investimento4Img.color = branco;
        }
        if(PlayerPrefs.GetInt("investimentoKey") == 2)
        {
            investimento1Img.color = branco;
            investimento2Img.color = branco;
            investimento3Img.color = verde;
            investimento4Img.color = branco;
        }
        if(PlayerPrefs.GetInt("investimentoKey") == 3)
        {
            investimento1Img.color = branco;
            investimento2Img.color = branco;
            investimento3Img.color = branco;
            investimento4Img.color = verde;
        }
    }

    void Render()
    {
        if(PlayerPrefs.GetInt("moedasKey") > 0)
        {
            if(PlayerPrefs.GetInt("investimentoKey") == 0)
            {
                dinheiro = PlayerPrefs.GetInt("moedasKey") + (PlayerPrefs.GetInt("moedasKey") / 1000 * 5);
            }
            if(PlayerPrefs.GetInt("investimentoKey") == 1)
            {
                dinheiro = PlayerPrefs.GetInt("moedasKey") + (PlayerPrefs.GetInt("moedasKey") / 100 * 1);
                perder = Random.Range(1, 1001);
                if(perder == 1)
                {
                    dinheiro = 0;
                }
            }
            if(PlayerPrefs.GetInt("investimentoKey") == 2)
            {
                dinheiro = PlayerPrefs.GetInt("moedasKey") + (PlayerPrefs.GetInt("moedasKey") / 100 * 5);
                perder = Random.Range(1, 101);
                if(perder == 1)
                {
                    dinheiro = 0;
                }
            }
            if(PlayerPrefs.GetInt("investimentoKey") == 3)
            {
                dinheiro = PlayerPrefs.GetInt("moedasKey") + (PlayerPrefs.GetInt("moedasKey") / 100 * 10);
                perder = Random.Range(1, 21);
                if(perder == 1)
                {
                    dinheiro = 0;
                }
            }
        }

        PlayerPrefs.SetInt("moedasKey", (int)dinheiro);
        dinheiro = PlayerPrefs.GetInt("moedasKey");
    }

    public void Investir(int investimento)
    {
        if(investimento == 1)
        {
            investimento1Img.color = verde;
            investimento2Img.color = branco;
            investimento3Img.color = branco;
            investimento4Img.color = branco;
            PlayerPrefs.SetInt("investimentoKey", 0);
        }
        if(investimento == 2)
        {
            investimento1Img.color = branco;
            investimento2Img.color = verde;
            investimento3Img.color = branco;
            investimento4Img.color = branco;
            PlayerPrefs.SetInt("investimentoKey", 1);
        }
        if(investimento == 3)
        {
            investimento1Img.color = branco;
            investimento2Img.color = branco;
            investimento3Img.color = verde;
            investimento4Img.color = branco;
            PlayerPrefs.SetInt("investimentoKey", 2);
        }
        if(investimento == 4)
        {
            investimento1Img.color = branco;
            investimento2Img.color = branco;
            investimento3Img.color = branco;
            investimento4Img.color = verde;
            PlayerPrefs.SetInt("investimentoKey", 3);
        }
    }
}
