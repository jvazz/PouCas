using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LucasPong : MonoBehaviour
{
    public int jogadores = 0;
    public GameObject bola;
    public GameObject painelEscolhaJogadores;
    public GameObject painelPlay;
    public GameObject botoesJogador2;
    public int vouJogar = 0;
    public float velocidade;
    public Vector3 posicaoBola;
    public GameObject jogador2;
    public GameObject jogador1;
    public GameObject painelPause;
    float tempo;
    public Text tempoTxt;

    // Start is called before the first frame update
    void Start()
    {
        posicaoBola = new Vector3(bola.transform.position.x, jogador2.transform.position.y, jogador2.transform.position.z);
        painelEscolhaJogadores.SetActive(true);
        painelPlay.SetActive(false);
        painelPause.SetActive(false);
        tempoTxt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(jogadores == 1)
        {
            jogador2.transform.position = Vector3.MoveTowards(jogador2.transform.position, posicaoBola, velocidade);
        }

        if(jogador1.transform.position.x > 1.78)
        {
            jogador1.transform.position = new Vector3(1.78f, jogador1.transform.position.y, jogador1.transform.position.z);
        }
        if(jogador1.transform.position.x < -1.78)
        {
            jogador1.transform.position = new Vector3(-1.78f, jogador1.transform.position.y, jogador1.transform.position.z);
        }

        if(jogador2.transform.position.x > 1.78)
        {
            jogador2.transform.position = new Vector3(1.78f, jogador2.transform.position.y, jogador2.transform.position.z);
        }
        if(jogador2.transform.position.x < -1.78)
        {
            jogador2.transform.position = new Vector3(-1.78f, jogador2.transform.position.y, jogador2.transform.position.z);
        }

        if(Input.GetKey(KeyCode.A))
        {
            jogador1.transform.position -= transform.right * 0.01f;
        }
        if(Input.GetKey(KeyCode.D))
        {
            jogador1.transform.position += transform.right * 0.01f;
        }
        
        if(jogadores == 2)
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                jogador2.transform.position -= transform.right * 0.01f;
            }
            if(Input.GetKey(KeyCode.RightArrow))
            {
                jogador2.transform.position += transform.right * 0.01f;
            }
        }

        if(bola.GetComponent<Bola>().jaComecou == true)
        {
            tempoTxt.enabled = true;
            tempo += Time.deltaTime;
            tempoTxt.text = tempo.ToString("F0");
        }
    }

    public void Jogador2Jogar()
    {
        if(jogadores == 1)
        {
            vouJogar = Random.Range(0, 21);
            if(vouJogar < 20)
            {
                posicaoBola = new Vector3(bola.transform.position.x, jogador2.transform.position.y, jogador2.transform.position.z);
                jogador2.transform.position = Vector3.MoveTowards(jogador2.transform.position, posicaoBola, velocidade);
                Invoke("AtualizarPosicaoBola", 1f);
            }else
            {
                posicaoBola = new Vector3(-bola.transform.position.x, jogador2.transform.position.y, jogador2.transform.position.z);
            }  
        }
    }

    void AtualizarPosicaoBola()
    {
        posicaoBola = new Vector3(bola.transform.position.x, jogador2.transform.position.y, jogador2.transform.position.z);
    }

    public void Voltar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void Jogadores1()
    {
        jogadores = 1;
        painelEscolhaJogadores.SetActive(false);
        painelPlay.SetActive(true);
        botoesJogador2.SetActive(false);
    }
    public void Jogadores2()
    {
        jogadores = 2;
        painelEscolhaJogadores.SetActive(false);
        painelPlay.SetActive(true);
        botoesJogador2.SetActive(true);
    }

    public void Play()
    {
        painelPlay.SetActive(false);
        bola.GetComponent<Bola>().jaComecou = true;
    }

    public void VoltarSelecaoJogadores()
    {
        jogadores = 0;
        painelEscolhaJogadores.SetActive(true);
        painelPlay.SetActive(false);
    }

    public void EsquerdaJogador1()
    {
        jogador1.transform.position -= transform.right * 0.1f;
    }
    public void EsquerdaJogador2()
    {
        jogador2.transform.position += transform.right * 0.1f;
    }
    public void DireitaJogador1()
    {
        jogador1.transform.position += transform.right * 0.1f;
    }
    public void DireitaJogador2()
    {
        jogador2.transform.position -= transform.right * 0.1f;
    }

    public void OKbtn()
    {
        SceneManager.LoadScene("LucasPong");
    }

    public void Pause()
    {
        painelPause.SetActive(true);
        Time.timeScale = 0f;
    }
    public void FecharPause()
    {
        painelPause.SetActive(false);
        Time.timeScale = 1f;
    }
}
