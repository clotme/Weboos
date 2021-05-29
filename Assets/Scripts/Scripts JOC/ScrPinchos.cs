using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPinchos : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per treure vida als players si cauen a sobre de pinxos.
    /// AUTOR:  Lídia García Romero
    /// DATA:   19/05/2021
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: es crea l'script i funciona perfectament.
    /// ----------------------------------------------------------------------------------
    /// </summary>

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<ScrPlayer>().vida -= 5;
        }
    }
}
