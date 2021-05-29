using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrBomba : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per programar el moviment de la bomba
    /// AUTOR:  Lídia García Romero
    /// DATA:   19/05/2021
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: Es crea l'script. 
    /// ----------------------------------------------------------------------------------
    /// </summary>
    /// 

    float velocitatX = 3, fY = 300;
    Rigidbody2D rb;

    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        rb.velocity = new Vector2(velocitatX, rb.velocity.y);
    }
}
