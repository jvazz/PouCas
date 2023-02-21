using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private int moedasTotais;
    public Text moedasTxt;
    public Slider fome, sono, felicidade;

    public GameObject painelMinigames, painelLoja;
    public GameObject painelMercado, painelRoupas, painelIngressos, painelInvestimentos;
    public GameObject painelCozinha, painelArmario, painelQuarto, painelEstadio;

    GameObject cozinhaBtn, armarioBtn, quartoBtn, estadioBtn;
    public GameObject fundoCozinha, fundoArmario, fundoQuarto, fundoEstadio;

    void Start()
    {
        //Screen.SetResolution(720, 1512, true);
        cozinhaBtn = GameObject.Find("CozinhaBtn");
        armarioBtn = GameObject.Find("ArmarioBtn");
        quartoBtn = GameObject.Find("QuartoBtn");
        estadioBtn = GameObject.Find("EstadioBtn");

        moedasTotais = PlayerPrefs.GetInt("moedasKey");
        painelMinigames.SetActive(false);
        if(PlayerPrefs.GetInt("primeiraKey") == 0)
        {
            PlayerPrefs.SetInt("primeiraKey", 1);
            PlayerPrefs.SetFloat("fomeKey", 1);
            PlayerPrefs.SetFloat("sonoKey", 1);
            PlayerPrefs.SetFloat("felicidadeKey", 1);

            /*
            PlayerPrefs.GetInt("primeiraKey");
            PlayerPrefs.GetFloat("fomeKey");
            PlayerPrefs.GetFloat("sonoKey");
            PlayerPrefs.GetFloat("felicidadeKey");
            PlayerPrefs.GetInt("moedasKey");
            PlayerPrefs.GetInt("macasKey")
            PlayerPrefs.GetInt("waffleKey")
            PlayerPrefs.GetInt("macarraoKey")
            PlayerPrefs.GetInt("churrascoKey")
            PlayerPrefs.GetInt("roupasKey")
            PlayerPrefs.GetInt("roupaSelecionadaKey")
            PlayerPrefs.GetInt("planoGaloNaVeiaKey")
            PlayerPrefs.GetInt("ingressosKey")
            PlayerPrefs.GetInt("investimentoKey")
            */
        }

        fundoArmario.SetActive(false);
        fundoCozinha.SetActive(false);
        fundoEstadio.SetActive(false);
        fundoQuarto.SetActive(false);
    }

    void Update()
    {
        moedasTxt.text = PlayerPrefs.GetInt("moedasKey").ToString();
        fome.value = PlayerPrefs.GetFloat("fomeKey");
        sono.value = PlayerPrefs.GetFloat("sonoKey");
        felicidade.value = PlayerPrefs.GetFloat("felicidadeKey");

        if(Input.GetKeyDown(KeyCode.J))
        {
            PlayerPrefs.SetFloat("sonoKey", 0);
            PlayerPrefs.SetFloat("fomeKey", 0);
            PlayerPrefs.SetFloat("felicidadeKey", 0);
        }
    }

    void FixedUpdate()
    {
        if(PlayerPrefs.GetFloat("fomeKey") >= 0)
        {
            PlayerPrefs.SetFloat("fomeKey", PlayerPrefs.GetFloat("fomeKey") - 0.00008f);
        }
        if(PlayerPrefs.GetFloat("sonoKey") >= 0)
        {
            PlayerPrefs.SetFloat("sonoKey", PlayerPrefs.GetFloat("sonoKey") - 0.00007f);
        }
        if(PlayerPrefs.GetFloat("felicidadeKey") >= 0)
        {
            PlayerPrefs.SetFloat("felicidadeKey", PlayerPrefs.GetFloat("felicidadeKey") - 0.00002f);
        }
    }

    public void AbrirPainelMinigames()
    {
        painelMinigames.SetActive(true);
    }

    public void Fechar()
    {
        painelMinigames.SetActive(false);
        painelLoja.SetActive(false);

        painelCozinha.SetActive(false);
        painelArmario.SetActive(false);
        painelQuarto.SetActive(false);
        painelEstadio.SetActive(false);
        
        fundoArmario.SetActive(false);
        fundoCozinha.SetActive(false);
        fundoEstadio.SetActive(false);
        fundoQuarto.SetActive(false);
    }

    public void Matematica()
    {
        SceneManager.LoadScene("Matematica");
    }

    public void LucasPong()
    {
        SceneManager.LoadScene("LucasPong");
    }

    public void LucasBird()
    {
        SceneManager.LoadScene("LucasBird");
    }

    public void AbrirLoja()
    {
        painelLoja.SetActive(true);
    }

    public void AbrirMercado()
    {
        painelLoja.SetActive(false);
        painelMercado.SetActive(true);
    }

    public void AbrirRoupas()
    {
        painelLoja.SetActive(false);
        painelRoupas.SetActive(true);
        armarioBtn.GetComponent<Roupas>().AtualizarBotoes();
    }

    public void AbrirIngressos()
    {
        painelLoja.SetActive(false);
        painelIngressos.SetActive(true);
        estadioBtn.GetComponent<Estadio>().AtualizarIngressos();
    }

    public void AbrirInvestimentos()
    {
        painelLoja.SetActive(false);
        painelInvestimentos.SetActive(true);
    }

    public void VoltarParaLoja()
    {
        painelLoja.SetActive(true);
        painelMercado.SetActive(false);
        painelRoupas.SetActive(false);
        painelIngressos.SetActive(false);
        painelInvestimentos.SetActive(false);
    }

    public void AbrirGerais(int comodo)
    {
        if(comodo == 1)
        {
            painelCozinha.SetActive(true);
            cozinhaBtn.GetComponent<Comida>().AtualizarQuantidade();
            fundoCozinha.SetActive(true);
        }
        if(comodo == 2)
        {
            painelArmario.SetActive(true);
            armarioBtn.GetComponent<Roupas>().AtualizarQuantidade();
            fundoArmario.SetActive(true);
        }
        if(comodo == 3)
        {
            painelQuarto.SetActive(true);
            quartoBtn.GetComponent<Dormir>().DormirAgora();
            fundoQuarto.SetActive(true);
        }
        if(comodo == 4)
        {
            painelEstadio.SetActive(true);
            estadioBtn.GetComponent<Estadio>().AtualizarIngressos();
            //fundoEstadio.SetActive(true);
        }
    }

    public void DevBtn()
    {
        PlayerPrefs.SetFloat("fomeKey", 0);
        PlayerPrefs.SetFloat("sonoKey", 0);
        PlayerPrefs.SetFloat("felicidadeKey", 0);
        PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") + 100000);
    }
}
