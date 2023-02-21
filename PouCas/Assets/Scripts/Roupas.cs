using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roupas : MonoBehaviour
{
    int precoRoupa1 = 10000;
    int precoRoupa2 = 20000;
    int precoRoupa3 = 30000;
    int precoRoupa4 = 100000;

    public Button roupa1Btn, roupa2Btn, roupa3Btn, roupa4Btn;
    public GameObject check1, check2, check3, check4;
    public GameObject imgComprada1, imgComprada2, imgComprada3, imgComprada4;
    public Sprite roupa0, roupa1, roupa2, roupa3, roupa4, roupa21;
    public GameObject poucas;
    SpriteRenderer poucasSpriteRenderer;
    public GameObject especialRoupaBtn;
    AudioSource sound;

    void Start()
    {
        poucasSpriteRenderer = poucas.GetComponent<SpriteRenderer>();
        sound = especialRoupaBtn.GetComponent<AudioSource>();

        if(PlayerPrefs.GetInt("roupaSelecionadaKey") == 0)
        {
            poucasSpriteRenderer.sprite = roupa0;
            especialRoupaBtn.SetActive(false);
        }
        if(PlayerPrefs.GetInt("roupaSelecionadaKey") == 1)
        {
            poucasSpriteRenderer.sprite = roupa1;
            especialRoupaBtn.SetActive(false);
        }
        if(PlayerPrefs.GetInt("roupaSelecionadaKey") == 2)
        {
            poucasSpriteRenderer.sprite = roupa2;
            especialRoupaBtn.SetActive(true);
        }
        if(PlayerPrefs.GetInt("roupaSelecionadaKey") == 3)
        {
            poucasSpriteRenderer.sprite = roupa3;
            especialRoupaBtn.SetActive(false);
        }
        if(PlayerPrefs.GetInt("roupaSelecionadaKey") == 4)
        {
            poucasSpriteRenderer.sprite = roupa4;
            especialRoupaBtn.SetActive(true);
        }
    }

    public void AtualizarQuantidade()
    {
        if(PlayerPrefs.GetInt("roupasKey") == 1)
        {
            imgComprada1.SetActive(true);
            imgComprada2.SetActive(false);
            imgComprada3.SetActive(false);
            imgComprada4.SetActive(false);
        }
        if(PlayerPrefs.GetInt("roupasKey") == 2)
        {
            imgComprada1.SetActive(true);
            imgComprada2.SetActive(true);
            imgComprada3.SetActive(false);
            imgComprada4.SetActive(false);
        }
        if(PlayerPrefs.GetInt("roupasKey") == 3)
        {
            imgComprada1.SetActive(true);
            imgComprada2.SetActive(true);
            imgComprada3.SetActive(true);
            imgComprada4.SetActive(false);
        }
        if(PlayerPrefs.GetInt("roupasKey") == 4)
        {
            imgComprada1.SetActive(true);
            imgComprada2.SetActive(true);
            imgComprada3.SetActive(true);
            imgComprada4.SetActive(true);
        }
    }

    public void ComprarRoupa()
    {
        if(PlayerPrefs.GetInt("roupasKey") == 3 && PlayerPrefs.GetInt("moedasKey") >= precoRoupa4)
        {
            PlayerPrefs.SetInt("roupasKey", PlayerPrefs.GetInt("roupasKey") + 1);
            PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") - precoRoupa4);
        }
        if(PlayerPrefs.GetInt("roupasKey") == 2 && PlayerPrefs.GetInt("moedasKey") >= precoRoupa3)
        {
            PlayerPrefs.SetInt("roupasKey", PlayerPrefs.GetInt("roupasKey") + 1);
            PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") - precoRoupa3);
        }
        if(PlayerPrefs.GetInt("roupasKey") == 1 && PlayerPrefs.GetInt("moedasKey") >= precoRoupa2)
        {
            PlayerPrefs.SetInt("roupasKey", PlayerPrefs.GetInt("roupasKey") + 1);
            PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") - precoRoupa2);
        }
        if(PlayerPrefs.GetInt("roupasKey") == 0 && PlayerPrefs.GetInt("moedasKey") >= precoRoupa1)
        {
            PlayerPrefs.SetInt("roupasKey", PlayerPrefs.GetInt("roupasKey") + 1);
            PlayerPrefs.SetInt("moedasKey", PlayerPrefs.GetInt("moedasKey") - precoRoupa1);
        }
        AtualizarBotoes();
    }

    public void AtualizarBotoes()
    {
        if(PlayerPrefs.GetInt("roupasKey") == 0)
        {
            roupa1Btn.interactable = true;
            roupa2Btn.interactable = false;
            roupa3Btn.interactable = false;
            roupa4Btn.interactable = false;
            check1.SetActive(false);
            check2.SetActive(false);
            check3.SetActive(false);
            check4.SetActive(false);
        }
        if(PlayerPrefs.GetInt("roupasKey") == 1)
        {
            roupa1Btn.interactable = false;
            roupa2Btn.interactable = true;
            roupa3Btn.interactable = false;
            roupa4Btn.interactable = false;
            check1.SetActive(true);
            check2.SetActive(false);
            check3.SetActive(false);
            check4.SetActive(false);
        }
        if(PlayerPrefs.GetInt("roupasKey") == 2)
        {
            roupa1Btn.interactable = false;
            roupa2Btn.interactable = false;
            roupa3Btn.interactable = true;
            roupa4Btn.interactable = false;
            check1.SetActive(true);
            check2.SetActive(true);
            check3.SetActive(false);
            check4.SetActive(false);
        }
        if(PlayerPrefs.GetInt("roupasKey") == 3)
        {
            roupa1Btn.interactable = false;
            roupa2Btn.interactable = false;
            roupa3Btn.interactable = false;
            roupa4Btn.interactable = true;
            check1.SetActive(true);
            check2.SetActive(true);
            check3.SetActive(true);
            check4.SetActive(false);
        }
        if(PlayerPrefs.GetInt("roupasKey") == 4)
        {
            roupa1Btn.interactable = false;
            roupa2Btn.interactable = false;
            roupa3Btn.interactable = false;
            roupa4Btn.interactable = false;
            check1.SetActive(true);
            check2.SetActive(true);
            check3.SetActive(true);
            check4.SetActive(true);
        }
    }

    public void SelecionarRoupa(int roupa)
    {
        if(roupa == 0)
        {
            if(PlayerPrefs.GetInt("roupasKey") >= 0)
            {
                PlayerPrefs.SetInt("roupaSelecionadaKey", 0);
                poucasSpriteRenderer.sprite = roupa0;
                especialRoupaBtn.SetActive(false);
            }
        }
        if(roupa == 1)
        {
            if(PlayerPrefs.GetInt("roupasKey") >= 1)
            {
                PlayerPrefs.SetInt("roupaSelecionadaKey", 1);
                poucasSpriteRenderer.sprite = roupa1;
                especialRoupaBtn.SetActive(false);
            }
        }
        if(roupa == 2)
        {
            if(PlayerPrefs.GetInt("roupasKey") >= 2)
            {
                PlayerPrefs.SetInt("roupaSelecionadaKey", 2);
                poucasSpriteRenderer.sprite = roupa2;
                especialRoupaBtn.SetActive(true);
            }
        }
        if(roupa == 3)
        {
            if(PlayerPrefs.GetInt("roupasKey") >= 3)
            {
                PlayerPrefs.SetInt("roupaSelecionadaKey", 3);
                poucasSpriteRenderer.sprite = roupa3;
                especialRoupaBtn.SetActive(false);
            }
        }
        if(roupa == 4)
        {
            if(PlayerPrefs.GetInt("roupasKey") >= 4)
            {
                PlayerPrefs.SetInt("roupaSelecionadaKey", 4);
                poucasSpriteRenderer.sprite = roupa4;
                especialRoupaBtn.SetActive(true);
            }
        }
    }

    public void EspecialRoupa()
    {
        if(PlayerPrefs.GetInt("roupaSelecionadaKey") == 2)
        {
            PlayerPrefs.SetInt("roupaSelecionadaKey", 21);
            poucasSpriteRenderer.sprite = roupa21;
        }
        else if(PlayerPrefs.GetInt("roupaSelecionadaKey") == 21)
        {
            PlayerPrefs.SetInt("roupaSelecionadaKey", 2);
            poucasSpriteRenderer.sprite = roupa2;
        }
        
        if(PlayerPrefs.GetInt("roupaSelecionadaKey") == 4)
        {
            sound.Play();
        }
    }

    public void RoupaCerta()
    {
        if(PlayerPrefs.GetInt("roupaSelecionadaKey") == 0)
        {
            poucasSpriteRenderer.sprite = roupa0;
            especialRoupaBtn.SetActive(false);
        }
        if(PlayerPrefs.GetInt("roupaSelecionadaKey") == 1)
        {
            poucasSpriteRenderer.sprite = roupa1;
            especialRoupaBtn.SetActive(false);
        }
        if(PlayerPrefs.GetInt("roupaSelecionadaKey") == 2)
        {
            poucasSpriteRenderer.sprite = roupa2;
            especialRoupaBtn.SetActive(true);
        }
        if(PlayerPrefs.GetInt("roupaSelecionadaKey") == 3)
        {
            poucasSpriteRenderer.sprite = roupa3;
            especialRoupaBtn.SetActive(false);
        }
        if(PlayerPrefs.GetInt("roupaSelecionadaKey") == 4)
        {
            poucasSpriteRenderer.sprite = roupa4;
            especialRoupaBtn.SetActive(true);
        }
    }
}
