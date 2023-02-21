using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour
{
    float sentido = 0.1f;
    public float direcao = 0;
    Vector3 newRotation;
    private int apontar = 0;
    public bool jaComecou = false;
    public GameObject controlador;
    public GameObject painelVitoria;
    public Text textoVitoria;
    public Image imagemPainelVitoria;
    public Color vermelho, azul;
    SpriteRenderer spriteRenderer;
    private float sentidoCodigo = 0.1f;
    Animator meuAnim;

    // Start is called before the first frame update
    void Start()
    {
        sentidoCodigo = 0.1f;
        sentido = sentidoCodigo;

        spriteRenderer = GetComponent<SpriteRenderer>();
        meuAnim = GetComponent<Animator>();

        apontar = Random.Range(0, 2);
        if(apontar == 0)
        {
            direcao = 180 + Random.Range(-10, 11);
            spriteRenderer.flipY = true;
        }
        if(apontar == 1)
        {
            direcao = 0 + Random.Range(-10, 11);
            spriteRenderer.flipY = false;
        }

        newRotation = new Vector3(0, 0, 0);
        transform.eulerAngles = new Vector3(0, 0, direcao);

        painelVitoria.SetActive(false);

        InvokeRepeating("GanharMoedas", 10f, 10f);
    }

    void GanharMoedas()
    {
        if(jaComecou)
        {
            PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") + 5);
            sentidoCodigo += 0.01f;
        }
    }

    void FixedUpdate()
    {
        if(jaComecou)
        {
            transform.position += transform.up * sentido;
            if(direcao == 0 || direcao == 180 || direcao == -180)
            {
                direcao = Random.Range(-5, 6);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.name == "Player1" || col.collider.name == "Player2")
        {
            meuAnim.SetTrigger("Colidiu");
            
            if(sentido > 0)
            {
                sentido = -sentidoCodigo;
            }
            else if(sentido < 0)
            {
                sentido = sentidoCodigo;
            }

            newRotation = new Vector3(0, 0, 0);
            //newRotation -= transform.forward * (direcao + Random.Range(-5, 6));
            newRotation -= transform.forward * (direcao + Random.Range(-10, 11));
            direcao = -direcao;
            //Vector3 newRotation = new Vector3(0, 0, 0);
            //newRotation += transform.forward * 10;
            transform.eulerAngles = newRotation;

            if(col.collider.name == "Player1")
            {
                controlador.GetComponent<LucasPong>().Jogador2Jogar();
            }
        }

        if(col.collider.name == "LateralE" || col.collider.name == "LateralD")
        {
            newRotation = new Vector3(0, 0, 0);
            newRotation -= transform.forward * (direcao);
            direcao = -direcao;
            transform.eulerAngles = newRotation;
        }

        if(col.collider.name == "GolJogador1")
        {
            if(controlador.GetComponent<LucasPong>().jogadores == 1)
            {
                painelVitoria.SetActive(true);
                textoVitoria.text = "Derrota";
            }else
            {
                painelVitoria.SetActive(true);
                textoVitoria.text = "Vitória: Jogador 2";
            }
            imagemPainelVitoria.color = vermelho;
            jaComecou = false;
        }
        if(col.collider.name == "GolJogador2")
        {
            if(controlador.GetComponent<LucasPong>().jogadores == 1)
            {
                painelVitoria.SetActive(true);
                textoVitoria.text = "Vitória";
            }else
            {
                painelVitoria.SetActive(true);
                textoVitoria.text = "Vitória: Jogador 1";
            }
            imagemPainelVitoria.color = azul;
            jaComecou = false;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.collider.name == "Player1" || col.collider.name == "Player2")
        {
            meuAnim.SetTrigger("Colidiu");
            
            if(sentido > 0)
            {
                sentido = -sentidoCodigo;
            }
            else if(sentido < 0)
            {
                sentido = sentidoCodigo;
            }

            newRotation = new Vector3(0, 0, 0);
            //newRotation -= transform.forward * (direcao + Random.Range(-5, 6));
            newRotation -= transform.forward * (direcao + Random.Range(-10, 11));
            direcao = -direcao;
            //Vector3 newRotation = new Vector3(0, 0, 0);
            //newRotation += transform.forward * 10;
            transform.eulerAngles = newRotation;

            if(col.collider.name == "Player1")
            {
                controlador.GetComponent<LucasPong>().Jogador2Jogar();
            }
        }

        if(col.collider.name == "LateralE" || col.collider.name == "LateralD")
        {
            newRotation = new Vector3(0, 0, 0);
            newRotation -= transform.forward * (direcao);
            direcao = -direcao;
            transform.eulerAngles = newRotation;
        }

        if(col.collider.name == "GolJogador1")
        {
            if(controlador.GetComponent<LucasPong>().jogadores == 1)
            {
                painelVitoria.SetActive(true);
                textoVitoria.text = "Derrota";
            }else
            {
                painelVitoria.SetActive(true);
                textoVitoria.text = "Vitória: Jogador 2";
            }
            imagemPainelVitoria.color = vermelho;
            jaComecou = false;
        }
        if(col.collider.name == "GolJogador2")
        {
            if(controlador.GetComponent<LucasPong>().jogadores == 1)
            {
                painelVitoria.SetActive(true);
                textoVitoria.text = "Vitória";
            }else
            {
                painelVitoria.SetActive(true);
                textoVitoria.text = "Vitória: Jogador 1";
            }
            imagemPainelVitoria.color = azul;
            jaComecou = false;
        }
    }
}
