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
    /// VERSIÓ: 1.1
    /// CONTROL DE VERSIONS
    ///         1.0: Es crea l'script, el qual ajuda a solucionar molts problemes i gestionar
    ///         el joc, però no acaba de funcionar.
    ///             1.1: Es refina el funcionament de la selecció de personatges per fer que 
    ///             funcioni correctament.
    /// ----------------------------------------------------------------------------------
    /// </summary>

    public static int index1 = 0, index2 = 0;
    [SerializeField] static Sprite[] personatges; //la llista amb les diferents aparençes

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        print("Player 1 - " + index1 + " Player 2 - " + index2);
    }

    public void CanviarSkin(int playerID, SpriteRenderer cap)
    {
        print("hola");
        switch (playerID)
        {
            case 1:
                cap.sprite = personatges[index1];
                break;
            case 2:
                cap.sprite = personatges[index2];
                break;
        }
    }
}
