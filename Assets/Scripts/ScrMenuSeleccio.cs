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
    /// VERSIÓ: 2.0
    /// CONTROL DE VERSIONS
    ///         1.0: primera versió on només es programa el so dels botons i el botó back.
    ///         2.0: Es programa el començament de la selecció de personages, i es recorre
    ///             l'array correctament. Falta per programar la selecció de personatges
    ///             amb toggle group.
    /// ----------------------------------------------------------------------------------
    /// </summary>

    //Seleccio de personatges_____________________________________________________________
    [SerializeField] Image playerEscollit1, playerEscollit2;
    [SerializeField] Sprite[] personatges;
    int index1, index2 = 0;
    //____________________________________________________________________________________

    void Start()
    {
        
    }


    void Update()
    {
        //Seleccio de personatges_____________________________________________________________
        playerEscollit1.sprite = personatges[index1];
        playerEscollit2.sprite = personatges[index2];
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
            if (index1 >= 8) //per evitar un index out of range
            {
                index1 = 0;
            }

            else
            {
                index1 += 1;
            }
        }

        if (direccio == "esquerra")
        {
            if (index1 <= 0)
            {
                index1 = 8;
            }

            else
            {
                index1 -= 1;
            }
        }
    }

    public void PlayerArray2(string direccio) //Recorrer la llista de personatges
    {
        if (direccio == "dreta")
        {
            if (index2 >= 8) //per evitar un index out of range
            {
                index2 = 0;
            }

            else
            {
                index2 += 1;
            }
        }

        if (direccio == "esquerra")
        {
            if (index2 <= 0)
            {
                index2 = 8;
            }

            else
            {
                index2 -= 1;
            }
        }
    }
}
