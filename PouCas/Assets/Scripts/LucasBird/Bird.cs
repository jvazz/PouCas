using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D rb;
    bool podeJogar = true;
    BoxCollider2D boxCollider;
    public GameObject controlador;
    public GameObject olhoMorto;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = true;
        transform.localScale = new Vector3(0.5f,0.5f,transform.localScale.z);
        olhoMorto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(podeJogar)
            {
                rb.AddForce(transform.up * 300);
            }
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.collider.name == "TuboC" || col.collider.name == "TuboB")
        {
            podeJogar = false;
            Invoke("DesativarCollider", 0.1f);
            transform.localScale = new Vector3(0.6f,0.6f,transform.localScale.z);
            olhoMorto.SetActive(true);
            controlador.GetComponent<LucasBird>().Morrer();
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.name == "TuboC" || col.collider.name == "TuboB")
        {
            podeJogar = false;
            Invoke("DesativarCollider", 0.1f);
            transform.localScale = new Vector3(0.6f,0.6f,transform.localScale.z);
            olhoMorto.SetActive(true);
            controlador.GetComponent<LucasBird>().Morrer();
        }
    }

    public void Pular()
    {
        if(podeJogar)
        {
            rb.AddForce(transform.up * 300);
        }
    }

    void DesativarCollider()
    {
        boxCollider.enabled = false;
    }
}
