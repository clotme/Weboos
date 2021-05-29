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

    public float velocitatX, fY;
    public Rigidbody2D rb;


    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>();

        //establim valors aleatoris a la força y perque el moviment parabolic sigui diferent cada vegada
        fY = Random.Range(300, 500);

        rb.AddForce(new Vector2(0, fY));

        Destroy(gameObject, 5); //es destrueix després de 5 segons
    }


    void FixedUpdate()
    {
        rb.velocity = new Vector2(velocitatX, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<ScrPlayer>().vida -= 20;
            Destroy(gameObject);
        }
    }

}
