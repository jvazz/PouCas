using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatematicaScript : MonoBehaviour
{
    public GameObject painelDificuldade;
    public Text perguntaTxt;
    public GameObject painelCerto, painelErrado;
    public Slider tempoSlider;
    public Image fill;
    public Color vermelho, verde;
    public GameObject teclado;
    public GameObject tempoSliderGo;
    private int dificuldade = 0;
    private float resultado = 0;
    private float algoritmo1 = 0;
    private float algoritmo2 = 0;
    private int sinal = 0;
    private string algoritmo1Txt, algoritmo2Txt;
    private bool dificuladadeEscolhida = false;

    public static float resposta = 0;
    public static bool podePerguntar = true;

    void Start()
    {
        painelDificuldade.SetActive(true);
        painelCerto.SetActive(false);
        painelErrado.SetActive(false);
        tempoSlider.value = 1;
        fill.color = verde;
        tempoSliderGo.SetActive(false);
    }

    void Update()
    {
        if(dificuladadeEscolhida)
        {
            if(podePerguntar)
            {
                if(resposta == resultado || (resultado - resposta) < 0.001f && (resultado - resposta) > 0)
                {
                    painelCerto.SetActive(true);
                    Invoke("FecharPaineis", 0.17f);
                    GanharMoedas();
                }else
                {
                    if(dificuldade == 5)
                    {
                        if((resultado - resposta) < 0.001f && (resultado - resposta) > 0)
                        {
                            painelCerto.SetActive(true);
                            Invoke("FecharPaineis", 0.17f);
                            GanharMoedas();
                        }else
                        {
                            painelErrado.SetActive(true);
                            Invoke("FecharPaineis", 0.17f);
                        }
                    }else
                    {
                        painelErrado.SetActive(true);
                        Invoke("FecharPaineis", 0.17f);
                    }
                }

                tempoSlider.value = 1;
                fill.color = verde;
                Perguntar();
            }

            if(tempoSlider.value == 0)
            {
                tempoSlider.value = 1;
                fill.color = verde;
                painelErrado.SetActive(true);
                Invoke("FecharPaineis", 0.17f);
                GanharMoedas();
                teclado.GetComponent<Teclado>().Deletar();
                Perguntar();
            }
        }
    }

    void FixedUpdate()
    {
        if(dificuladadeEscolhida)
        {
            tempoSlider.value -= 0.002f;
        }
        if(tempoSlider.value < 0.3)
        {
            fill.color = vermelho;
        }
    }

    void GanharMoedas()
    {
        PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") + dificuldade * 5);
    }

    void FecharPaineis()
    {
        painelCerto.SetActive(false);
        painelErrado.SetActive(false);
    }

    void Perguntar()
    {
        podePerguntar = false;

        if(dificuldade == 1)
        {
            algoritmo1 = Random.Range(1, 11);
            algoritmo2 = Random.Range(1, 11);
            perguntaTxt.text = algoritmo1 + " + " + algoritmo2;
            resultado = algoritmo1 + algoritmo2;
        }
        if(dificuldade == 2)
        {
            algoritmo1 = Random.Range(1, 101);
            algoritmo2 = Random.Range(1, 101);
            perguntaTxt.text = algoritmo1 + " + " + algoritmo2;
            resultado = algoritmo1 + algoritmo2;
        }
        if(dificuldade == 3)
        {
            algoritmo2 = Random.Range(1, 101);
            algoritmo1 = algoritmo2 + Random.Range(1, 101);
            sinal = Random.Range(1, 3);
            if(sinal == 1)
            {
                perguntaTxt.text = algoritmo1 + " + " + algoritmo2;
                resultado = algoritmo1 + algoritmo2;
            }
            else if(sinal == 2)
            {
                perguntaTxt.text = algoritmo1 + " - " + algoritmo2;
                resultado = algoritmo1 - algoritmo2;
            }
        }
        if(dificuldade == 4)
        {
            algoritmo2Txt = Random.Range(1, 101) + "," + Random.Range(0, 11);
            algoritmo1Txt = Random.Range(1, 101) + "," + Random.Range(0, 11);
            algoritmo1 = float.Parse(algoritmo1Txt);
            algoritmo2 = float.Parse(algoritmo2Txt);
            algoritmo1 = (int)algoritmo2 + algoritmo1;
            sinal = Random.Range(1, 3);
            if(sinal == 1)
            {
                perguntaTxt.text = algoritmo1 + " + " + algoritmo2;
                resultado = algoritmo1 + algoritmo2;
            }
            else if(sinal == 2)
            {
                perguntaTxt.text = algoritmo1 + " - " + algoritmo2;
                resultado = algoritmo1 - algoritmo2;
            }
        }
        if(dificuldade == 5)
        {
            algoritmo2 = Random.Range(1, 101);
            algoritmo1 = algoritmo2 + Random.Range(1, 101);
            sinal = Random.Range(1, 5);
            if(sinal == 1)
            {
                perguntaTxt.text = algoritmo1 + " + " + algoritmo2;
                resultado = algoritmo1 + algoritmo2;
            }
            if(sinal == 2)
            {
                perguntaTxt.text = algoritmo1 + " - " + algoritmo2;
                resultado = algoritmo1 - algoritmo2;
            }
            if(sinal == 3)
            {
                perguntaTxt.text = algoritmo1 + " X " + algoritmo2;
                resultado = algoritmo1 * algoritmo2;
            }
            if(sinal == 4)
            {
                perguntaTxt.text = algoritmo1 + " / " + algoritmo2;
                resultado = algoritmo1 / algoritmo2;
            }
        }
    }

    //Random.Range(0, 1000).ToString("0000") + ")";

    public void Voltar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MuitoFácil()
    {
        painelDificuldade.SetActive(false);
        dificuldade = 1;
        dificuladadeEscolhida = true;
        tempoSliderGo.SetActive(true);
        Perguntar();
    }
    public void Fácil()
    {
        painelDificuldade.SetActive(false);
        dificuldade = 2;
        dificuladadeEscolhida = true;
        tempoSliderGo.SetActive(true);
        Perguntar();
    }
    public void Médio()
    {
        painelDificuldade.SetActive(false);
        dificuldade = 3;
        dificuladadeEscolhida = true;
        tempoSliderGo.SetActive(true);
        Perguntar();
    }
    public void Difícil()
    {
        painelDificuldade.SetActive(false);
        dificuldade = 4;
        dificuladadeEscolhida = true;
        tempoSliderGo.SetActive(true);
        Perguntar();
    }
    public void MuitoDifícil()
    {
        painelDificuldade.SetActive(false);
        dificuldade = 5;
        dificuladadeEscolhida = true;
        tempoSliderGo.SetActive(true);
        Perguntar();
    }
}
