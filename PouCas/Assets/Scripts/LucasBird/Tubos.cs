using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubos : MonoBehaviour
{   
    public GameObject controlador;

    void Start()
    {
        transform.position += transform.up * Random.Range(-2.0f, 3.0f);
    }

    void Update()
    {
        transform.position -= transform.right * 3f * Time.deltaTime;

        if(gameObject.name == "Tubo1")
        {
            if(transform.position.x < -4 && transform.position.x > -4.1f)
            {
                transform.position = new Vector2(6, 0);
                transform.position += transform.up * Random.Range(-2.0f, 3.0f);
            }
        }
        if(gameObject.name == "Tubo2")
        {
            if(transform.position.x < -4 && transform.position.x > -4.1f)
            {
                transform.position = new Vector2(6, 0);
                transform.position += transform.up * Random.Range(-2.0f, 3.0f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Bird")
        {
            controlador.GetComponent<LucasBird>().Pontuar();
        }
    }
}