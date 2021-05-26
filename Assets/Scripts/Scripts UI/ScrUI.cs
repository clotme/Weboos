using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrUI : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per la gestió de la UI durant el joc i tots els elements que
    ///         hi surten.
    /// AUTOR:  Lídia García Romero
    /// DATA:   12/05/2021
    /// VERSIÓ: 2.0
    /// CONTROL DE VERSIONS
    ///         1.0: Únicament es crea l'script per gestionar la variable steps, ja que ajuda
    ///         amb la programació del moviment del player.
    ///             1.1: Es refina que surti el nom del player quan sigui el seu torn.
    ///             1.2: Es perfecciona i s'adapta el vinculament dels steps.
    ///         2.0: Es programa la varra de vida.
    /// ----------------------------------------------------------------------------------
    /// </summary>

    [SerializeField] GameObject controlGame; //Per accedir a les variables del control game
    [SerializeField] GameObject[] players;

    //Pels steps_________________________________________________________________________
    [SerializeField] GameObject controlTorns;
    [SerializeField] Text steps, nomPlayerTirada;
    [SerializeField] GameObject aniDau;
    //___________________________________________________________________________________

    //Per la vida________________________________________________________________________
    [SerializeField] Image barraVida1, barraVida2;
    //___________________________________________________________________________________

    //pel nom dels jugadors______________________________________________________________
    [SerializeField] Text nomPlayer1, nomPlayer2;
    //___________________________________________________________________________________

    private void Start()
    {
        //Pel nom del jugador________________________________________________________________
        nomPlayer1.text = ScrControlGame.nomPlayer1;
        nomPlayer2.text = ScrControlGame.nomPlayer2;
        //___________________________________________________________________________________
    }

    void Update()
    {
     //Pels steps__________________________________________________________________________
     switch (controlTorns.GetComponent<ScrTorns>().tornActual)
        {
            case 0:
                steps.text = (" ");
                nomPlayerTirada.text = ScrControlGame.nomPlayer1;
                break;

            case 1:
                if (aniDau.GetComponent<ScrAniDau>().aniAcabada)
                {
                    steps.text = players[0].GetComponent<ScrPlayer>().tTirada.ToString("F0");
                    nomPlayerTirada.text = (" ");
                }                
                break;

            case 2:
                if (aniDau.GetComponent<ScrAniDau>().aniAcabada)
                {
                    steps.text = players[1].GetComponent<ScrPlayer>().tTirada.ToString("F0");
                    nomPlayerTirada.text = (" ");
                }                    
                break;

            case 3:
                steps.text = (" ");
                nomPlayerTirada.text = ScrControlGame.nomPlayer2;
                break;

            case 4:
                steps.text = (" ");
                nomPlayerTirada.text = ScrControlGame.nomPlayer1;
                break;

            case 5:
                steps.text = (" ");
                nomPlayerTirada.text = (" ");
                break;
        }
        //___________________________________________________________________________________

        //Per la vida________________________________________________________________________
        barraVida1.fillAmount = (players[0].GetComponent<ScrPlayer>().vida)/30;
        barraVida2.fillAmount = (players[1].GetComponent<ScrPlayer>().vida)/30;
        //___________________________________________________________________________________
    }
}
