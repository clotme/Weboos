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
    /// VERSIÓ: 1.1
    /// CONTROL DE VERSIONS
    ///         1.0: Únicament es crea l'script per gestionar la variable steps, ja que ajuda
    ///             amb la programació del moviment del player.
    ///         1.1: Es refina que surti el nom del player quan sigui el seu torn.
    /// ----------------------------------------------------------------------------------
    /// </summary>

    [SerializeField] GameObject controlGame; //Per accedir a les variables del control game

    [SerializeField] GameObject controlTorns;
    [SerializeField] GameObject[] players;

    [SerializeField] Text steps, nomPlayerTirada;

    void Start()
    {
     
    }


    void Update()
    {
     //Pels steps__________________________________________________________________________
     switch (controlTorns.GetComponent<ScrTorns>().tornActual)
        {
            case 0:
                steps.text = (" ");
                nomPlayerTirada.text = controlGame.GetComponent<ScrControlGame>().nomPlayer1;
                break;

            case 1:
                steps.text = players[0].GetComponent<ScrPlayer>().tTirada.ToString("F0");
                nomPlayerTirada.text = (" ");
                break;

            case 2:
                steps.text = players[1].GetComponent<ScrPlayer>().tTirada.ToString("F0");
                nomPlayerTirada.text = (" ");
                break;

            case 3:
                steps.text = (" ");
                nomPlayerTirada.text = controlGame.GetComponent<ScrControlGame>().nomPlayer2;
                break;

            case 4:
                steps.text = (" ");
                nomPlayerTirada.text = controlGame.GetComponent<ScrControlGame>().nomPlayer1;
                break;

            case 5:
                steps.text = (" ");
                nomPlayerTirada.text = (" ");
                break;
      //___________________________________________________________________________________
        }
    }
}
