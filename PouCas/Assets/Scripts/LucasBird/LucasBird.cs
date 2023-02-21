using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LucasBird : MonoBehaviour
{
    public GameObject painelPlay;
    public GameObject painelPerdeu;
    public GameObject painelPause;
    public Text pontosTxt;
    public int pontos = 0;


    void Start()
    {
        painelPlay.SetActive(true);
        painelPerdeu.SetActive(false);
        painelPause.SetActive(false);
        Time.timeScale = 0f;
    }

    void Update()
    {
        pontosTxt.text = pontos.ToString();
    }

    public void Play()
    {
        Time.timeScale = 1f;
        painelPlay.SetActive(false);
        painelPause.SetActive(false);
    }
    
    public void Voltar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void Morrer()
    {
        Invoke("Perdeu", 2f);
    }

    void Perdeu()
    {
        painelPerdeu.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void JogarDeNovo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LucasBird");
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        painelPause.SetActive(true);
    }

    public void Pontuar()
    {
        pontos++;
        PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") + 5);
    }
}
