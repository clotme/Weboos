using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrTorns : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per gestionar tot els possibles estats en el quals es pot
    ///         trobar el joc. 
    /// AUTOR:  Lídia García Romero
    /// DATA:   12/05/2021
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: Es crea la variable tornActual i es defineixen els estats del joc.
    /// ----------------------------------------------------------------------------------
    /// </summary>

    public int tornActual = 0; //de valors entre 0 i 5
    //0 = inici joc
    //1 = torn player 1
    //2 = torn player 2
    //3 = torn transició entre 1 - 2
    //4 = torn transició entre 2 - 1
    //5 = fi de joc


    void Update()
    {
        print(tornActual);
    }
}
