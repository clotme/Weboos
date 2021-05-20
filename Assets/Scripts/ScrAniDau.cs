using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrAniDau : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per l'animació del dau que dona el temps per cada tirada.
    /// AUTOR:  Lidia García Romero
    /// DATA:   17/05/2021
    /// VERSIÓ: 1.1
    /// CONTROL DE VERSIONS
    ///         1.0: Es crea la màquina d'estats i funciona correctament.
    ///             1.1: Es perfecciona amb booleanes la determinació de quan acaba l'animació.
    /// ----------------------------------------------------------------------------------
    /// </summary>

    Animator anim;
    public bool aniAcabada;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            anim.SetBool("StartDau", true);
            aniAcabada = false;
        }
    }

    public void AcabarAnimacio()
    {
        anim.SetBool("StartDau", false);
        aniAcabada = true;
    }
}
