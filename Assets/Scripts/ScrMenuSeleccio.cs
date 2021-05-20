using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrMenuSeleccio : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per gestionar la pantalla de menú de selecció.
    /// AUTOR:  Lídia García Romero
    /// DATA:   17/05/2021
    /// VERSIÓ: 2.2
    /// CONTROL DE VERSIONS
    ///         1.0: primera versió on només es programa el so dels botons i el botó back.
    ///         2.0: Es programa el començament de la selecció de personages, i es recorre
    ///         l'array correctament. Falta per programar la selecció de personatges
    ///         amb toggle group.
    ///             2.1: Es programa la selecció des del toggle group i funciona.
    ///             2.2: Es programa el canvi de nivell (només cap al nivell 1, un prototip)
    /// ----------------------------------------------------------------------------------
    /// </summary>


    public GameObject controlSkins;
    
    //Seleccio de personatges_____________________________________________________________
    [SerializeField] Image playerEscollit1, playerEscollit2;
    [SerializeField] Sprite[] personatges;

    bool isSeleccionat1 = false, isSeleccionat2 = false; //determina si la selecció es final
    //____________________________________________________________________________________

    //Canvi de nivell_____________________________________________________________________
    string[] nivells = new string[3] {"Nivell1", "Nivell2", "Nivell3"};
    //____________________________________________________________________________________


    void Update()
    {
        //Seleccio de personatges_____________________________________________________________
        playerEscollit1.sprite = personatges[ScrSkin.index1];
        playerEscollit2.sprite = personatges[ScrSkin.index2];

        if(isSeleccionat1 && isSeleccionat2) //els dos players ja han escollit jugador, així que el joc pot començar
        {
            SceneManager.LoadScene(nivells[0]);
        }    
        //____________________________________________________________________________________
}

    public void ReproduirSo(AudioSource so)
    {
        so.Play();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Inici");
    }

    public void PlayerArray1(string direccio) //Recorrer la llista de personatges
    {
        if (direccio == "dreta")
        {
            if (ScrSkin.index1 >= 8) //per evitar un index out of range
            {
                ScrSkin.index1 = 0;
            }

            else
            {
                ScrSkin.index1 += 1;
            }
        }

        if (direccio == "esquerra")
        {
            if (ScrSkin.index1 <= 0)
            {
                ScrSkin.index1 = 8;
            }

            else
            {
                ScrSkin.index1 -= 1;
            }
        }
    }

    public void PlayerArray2(string direccio) //Recorrer la llista de personatges
    {
        if (direccio == "dreta")
        {
            if (ScrSkin.index2 >= 8) //per evitar un index out of range
            {
                ScrSkin.index2 = 0;
            }

            else
            {
                ScrSkin.index2 += 1;
            }
        }

        if (direccio == "esquerra")
        {
            if (ScrSkin.index2 <= 0)
            {
                ScrSkin.index2 = 8;
            }

            else
            {
                ScrSkin.index2 -= 1;
            }
        }
    }

    public void ToggleCanviarPersonatge1(int numPersonatge) //Canviar el personatge des del toggle group
    {
        ScrSkin.index1 = numPersonatge;
    }

    public void ToggleCanviarPersonatge2(int numPersonatge)
    {
        ScrSkin.index2 = numPersonatge;
    }

    public void Seleccionar(int idPlayer)
    {
        switch (idPlayer)
        {
            case 1:
                isSeleccionat1 = true;
                break;
            case 2:
                isSeleccionat2 = true;
                break;
        }
    }
}
