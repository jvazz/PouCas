using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dormir : MonoBehaviour
{
    public GameObject painelQuarto;
    bool dormindo;
    public GameObject poucasPijama;
    public GameObject poucas;
    public Camera cam;
    public Color corPadrao, corDormir;
    public GameObject fundoQuarto;

    void Start()
    {
        dormindo = false;
        poucasPijama.SetActive(false);
        poucas.SetActive(true);
        painelQuarto.SetActive(false);
        cam.backgroundColor = corPadrao;
    }

    void FixedUpdate()
    {
        if(dormindo)
        {
            if(PlayerPrefs.GetFloat("sonoKey") <= 0.999)
            {
                PlayerPrefs.SetFloat("sonoKey", PlayerPrefs.GetFloat("sonoKey") + 0.001f);
            }
        }
    }

    public void DormirAgora()
    {
        poucasPijama.SetActive(true);
        poucas.SetActive(false);
        dormindo = true;
        cam.backgroundColor = corDormir;
    }

    public void AcordarAgora()
    {
        dormindo = false;
        painelQuarto.SetActive(false);
        poucasPijama.SetActive(false);
        poucas.SetActive(true);
        cam.backgroundColor = corPadrao;
        fundoQuarto.SetActive(false);
    }
}
