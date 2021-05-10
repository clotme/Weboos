using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPlayer : MonoBehaviour
{

    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per tota la programació relacionada amb el player: moviment,
    ///         habilitats, animacions, característiques...
    /// AUTOR:  Lídia García Romero
    /// DATA:   10/05/2021
    /// VERSIÓ: 1.1
    /// CONTROL DE VERSIONS
    ///         1.0: Es crea el player i es programa el seu moviment i salt.
    ///         1.1: Es comença a programar el moviment per "steps", però encara no funciona.
    /// ----------------------------------------------------------------------------------
    /// </summary>

    //Pel moviment del player_____________________________________________________________
    Rigidbody2D rb;
    float moviment;
    [SerializeField] float velocitat = 3, fSalt = 400;
    bool miraDreta = true;
    //____________________________________________________________________________________

    //Pel salt____________________________________________________________________________
    bool salta = false, onTerra = false;
    [SerializeField] Transform checkTerra;
    [SerializeField] public LayerMask filtreCapes; //Per la capa dels terres
    float radi = 0.2f;
    //____________________________________________________________________________________

    //Pels steps__________________________________________________________________________
    int steps = 3; //es determinarà amb una tirada
    float fStep = 300; //per fer l'impuls del moviment
    //____________________________________________________________________________________
    
    void Start()
    {
        //Pel moviment del player_____________________________________________________________
        rb = GetComponent<Rigidbody2D>();
        //____________________________________________________________________________________
    }


    void Update()
    {
        //Pel moviment del player_____________________________________________________________
        moviment = Input.GetAxis("Horizontal");

        if ((moviment < 0 && miraDreta) || (moviment > 0 && !miraDreta)) FlipSprite();
        //____________________________________________________________________________________

        //Pel salt____________________________________________________________________________
        if (Input.GetButtonDown("Jump") && onTerra) salta = true;
        //____________________________________________________________________________________

        //Pels steps PROTOTIP_________________________________________________________________
        print(steps);
        //____________________________________________________________________________________
    }

    private void FixedUpdate()
    {
        //Pel moviment del player_____________________________________________________________
        rb.velocity = new Vector2(moviment * velocitat, rb.velocity.y); //posem velocity.y al eix y perque sino tindria conflictes amb la gravetat
        //____________________________________________________________________________________

        //Pel salt____________________________________________________________________________
        onTerra = Physics2D.OverlapCircle(checkTerra.position, radi, filtreCapes); //detectar si està entrant en contacte amb el terra

        if(salta && onTerra) //salt
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, fSalt));
        }

        salta = false;
        //____________________________________________________________________________________


        //Pels steps__________________________________________________________________________
        
        //____________________________________________________________________________________
    }

    void FlipSprite()
    {
        miraDreta = !miraDreta;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z); //fem el flip multiplicant per -1 la escala x 
    }
}
