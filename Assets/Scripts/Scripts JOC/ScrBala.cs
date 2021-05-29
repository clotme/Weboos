using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrBala : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat pel moviment de la bala
    /// AUTOR:  Lídia García Romero
    /// DATA:   29/05/2021
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: Es crea l'Script
    /// ----------------------------------------------------------------------------------
    /// </summary>

    public float velocitat = 20f;
    [SerializeField] GameObject torns;

    
    void Start()
    {
        Destroy(gameObject, 3); //es destrueix després de 3 segons
    }


    void Update()
    {
        transform.Translate(velocitat * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<ScrPlayer>().vida -= 10;
            Destroy(gameObject);
        }
    }
}
