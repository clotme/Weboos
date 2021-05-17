using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrControlGame : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat pels controls generals del joc i la seva gestió. Organitza
    ///         les vides, els torns, les tirades...
    /// AUTOR:  Lídia García Romero
    /// DATA:   12/05/2021
    /// VERSIÓ: 1.3
    /// CONTROL DE VERSIONS
    ///         1.0: Es crea i s'afegeix la funció de tirades (intent que no funciona).
    ///         1.1: Es perfecciona el sistema de torns amb un altre scipt (ScrTorns).
    ///         1.2: S'acaba i funciona perfecte el sistema de torns.
    ///         1.3: Es refina que surti el nom del player quan sigui el seu torn i el
    ///             delay pel dau.
    /// ----------------------------------------------------------------------------------
    /// </summary>

    //Per gestió dels jugadors____________________________________________________________
    public string nomPlayer1 = "Player 1", nomPlayer2 = "Player 2"; 
    [SerializeField] GameObject[] players;
    //____________________________________________________________________________________

    //Pels torns__________________________________________________________________________
    [SerializeField] GameObject dauTxt;
    [SerializeField] Text dau, nom;
    public int numTirada;
    [SerializeField] GameObject controlTorns;
    float tempsDelay = 2f; //el temps que passarà abans d'amagar el dau
    float tempsAniDau = 1f; //el temps que dura l'animació del dau
    //____________________________________________________________________________________

    void Start()
    {  
        //Pels torns__________________________________________________________________________        
        dauTxt.SetActive(true);
        dau.gameObject.SetActive(false);
        nom.gameObject.SetActive(true);
        //____________________________________________________________________________________
    }


    void Update()
    {
        //Pels torns__________________________________________________________________________
        if ((controlTorns.GetComponent<ScrTorns>().tornActual != 1 || controlTorns.GetComponent<ScrTorns>().tornActual != 2) && Input.GetKeyDown(KeyCode.Return)) //quan es presiona ENTER, es calcula els segons de tirada
        {
            dauTxt.SetActive(false);
            nom.gameObject.SetActive(false);

            tempsDelay = 2f; //resetegem el valor del temps del delay
            tempsAniDau = 1f;

            numTirada = Random.Range(1, 11); //generem un temps de tirada aleatori
            dau.text = numTirada.ToString();

            if(controlTorns.GetComponent<ScrTorns>().tornActual == 3) //torn player 2
            {
                players[1].GetComponent<ScrPlayer>().tTirada = numTirada + 1; //li assignem al player el temps que ha sortit al dau per moure's (més el temps de l'animació)
                controlTorns.GetComponent<ScrTorns>().tornActual = 2;
            }

            else
            {
                players[0].GetComponent<ScrPlayer>().tTirada = numTirada + 1; //li assignem al player el temps que ha sortit al dau per moure's (més el temps de l'animació)
                controlTorns.GetComponent<ScrTorns>().tornActual = 1; //torn player 1
            }
        }

        //Delay del dau_______________________________________________________________________
        tempsAniDau -= Time.deltaTime;

        if (tempsAniDau < 0)
        {
            dau.gameObject.SetActive(true);
        }
        
        tempsDelay -= Time.deltaTime;

        if (tempsDelay < 0)
        {
            dau.gameObject.SetActive(false);
        }
        //____________________________________________________________________________________

        if (controlTorns.GetComponent<ScrTorns>().tornActual == 3 || controlTorns.GetComponent<ScrTorns>().tornActual == 4)
        {
            dauTxt.SetActive(true);
            dau.gameObject.SetActive(false);
            nom.gameObject.SetActive(true);
        }
        //____________________________________________________________________________________
    } 
}
