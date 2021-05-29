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
    /// VERSIÓ: 6.1
    /// CONTROL DE VERSIONS
    ///         1.0: Es crea el player i es programa el seu moviment i salt.
    ///             1.1: Es comença a programar el moviment per "steps", però encara no funciona.
    ///         2.0: Es canvia el métode. Ara es temps de moviment en comptes de "steps". S'aplica
    ///              i funciona el moviment, però no la gestió de torns.
    ///             2.1: Es perfeccionen aspectes de constrains. Moviment en torns funciona perfecte.
    ///             2.2: Es perfecciona el moviment del player. No es pot moure fins que 
    ///             l'animació del dau hagi acabat.
    ///         3.0: S'afegeix la programació de la màquina d'estats molt bàsica, però jump
    ///             no funciona.
    ///         4.0: S'afegeix el primer prototip de disparar (només animacions)
    ///         5.0: Es comença a programar la vida.
    ///         6.0: Es comença a programar la bomba i bala
    ///             6.1: s'acaba de programar la bala de la pistola, que funciona perfecta.
    /// ----------------------------------------------------------------------------------
    /// </summary>

    [SerializeField] int playerID; //de valor 1 o 2
    
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

    //Pel temps de tirada_________________________________________________________________
    public float tTirada = 2;
    public bool isTorn = false;
    bool haAtacat = false; //perque només pugui atacar una vegada per torn
    [SerializeField] GameObject controlTorns, aniDau;
    //____________________________________________________________________________________

    //Per la màquina d'estats_____________________________________________________________
    Animator anim;
    //____________________________________________________________________________________

    //Per l'aparença del personatge_______________________________________________________
    [SerializeField] Sprite[] personatges;
    [SerializeField] SpriteRenderer cap;
    ScrSkin ScrSkin;
    //____________________________________________________________________________________

    //Per disparar________________________________________________________________________
    bool disBomba, disPistola; //per la màquina d'estats

    [SerializeField] AudioSource soBomba, soPistola;

    [SerializeField] GameObject bomba, bala;
    [SerializeField] Transform cano;
    //____________________________________________________________________________________

    //Per la vida_________________________________________________________________________
    public float vida = 30f; //valor de vida inicial
    //____________________________________________________________________________________

    void Start()
    {
        //Pel moviment del player_____________________________________________________________
        rb = GetComponent<Rigidbody2D>();
        //____________________________________________________________________________________

        //Pel temps de tirada_________________________________________________________________
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        //____________________________________________________________________________________

        //Per la màquina d'estats_____________________________________________________________
        anim = GetComponent<Animator>();
        //____________________________________________________________________________________

        //Per l'aparença del personatge_______________________________________________________
        cap.sprite = personatges[ScrSkin.index1];
        //____________________________________________________________________________________
    }


    void Update()
    {
        //Pel moviment del player_____________________________________________________________
        moviment = Input.GetAxis("Horizontal");

        if (((moviment < 0 && miraDreta) || (moviment > 0 && !miraDreta)) && controlTorns.GetComponent<ScrTorns>().tornActual == playerID) FlipSprite();
        //____________________________________________________________________________________

        //Pel salt____________________________________________________________________________
        if (Input.GetButtonDown("Jump") && onTerra) salta = true;
        //____________________________________________________________________________________

        //Pel temps de tirada_________________________________________________________________
        if (controlTorns.GetComponent<ScrTorns>().tornActual == playerID && tTirada > 0 && aniDau.GetComponent<ScrAniDau>().aniAcabada) //és el teu torn i et pots moure
        {
            isTorn = true;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            tTirada -= Time.deltaTime;
        }

         else if (tTirada < 0) //s'ha acabat el torn i ja no et pots moure
        {
            isTorn = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            controlTorns.GetComponent<ScrTorns>().tornActual += 2;
            tTirada = 0;

            haAtacat = false;
        }
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

        //Per la màquina d'estats_____________________________________________________________
        anim.SetFloat("velocitat", Mathf.Abs(moviment));
        anim.SetBool("tocantTerra", onTerra);
        anim.SetBool("isTorn", isTorn);
        anim.SetBool("bomba", disBomba);
        anim.SetBool("pistola", disPistola);
        //____________________________________________________________________________________
    }


    void FlipSprite()
    {
        miraDreta = !miraDreta;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z); //fem el flip multiplicant per -1 la escala x 
    }


    public void TirarBomba()
    {
        if(controlTorns.GetComponent<ScrTorns>().tornActual == playerID && haAtacat == false)
        {
            Instantiate(bomba, cano.position, cano.rotation);
            bomba.GetComponent<ScrBomba>().rb.AddForce(new Vector2(0, bomba.GetComponent<ScrBomba>().fY));
            
            haAtacat = true;
        }        
    }

    public void DispararPistola()
    {
        if (controlTorns.GetComponent<ScrTorns>().tornActual == playerID && haAtacat == false)
        {
            if (!miraDreta && bala.GetComponent<ScrBala>().velocitat > 0) //si mira cap a l'esquella però la velocitat de la bala és negativa
            {
                bala.GetComponent<ScrBala>().velocitat *= -1;
            }

            if (miraDreta && bala.GetComponent<ScrBala>().velocitat < 0) //si mira cap a la dreta però la velocitat de la bala és positiva
            {
                bala.GetComponent<ScrBala>().velocitat *= -1;
            }
            
            Instantiate(bala, cano.position, cano.rotation);

            soPistola.Play();

            haAtacat = true;
        }
    }

    public void AcabarAniBomba()
    {
        disBomba = false;
    }

    public void AcabarAniPistola()
    {
        disPistola = false;
    }

    public void SetPistola(bool estat)
    {
        if (controlTorns.GetComponent<ScrTorns>().tornActual == playerID && haAtacat == false)
        {
            if (estat)
            {
                disPistola = true;
            }
        }        
    }

    public void SetBomba(bool estat)
    {
        if (controlTorns.GetComponent<ScrTorns>().tornActual == playerID && haAtacat == false)
        {
            if (estat)
            {
                disBomba = true;
            }
        }
    }
}
