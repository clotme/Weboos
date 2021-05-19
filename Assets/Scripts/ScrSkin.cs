using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrSkin : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per guardar les diferents aparençes que poden tenir els
    ///         players
    /// AUTOR:  Lídia García Romero
    /// DATA:   19/05/2021
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: Es crea l'script, el qual ajuda a solucionar molts problemes i gestionar
    ///         el joc.
    /// ----------------------------------------------------------------------------------
    /// </summary>

    public int index1 = 0, index2 = 0;
    public static ScrSkin instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        print("Player 1 - " + index1 + " Player 2 - " + index2);
    }
}
