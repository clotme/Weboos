using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrMenuSeleccio : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per gestionar la pantalla de menú de selecció.
    /// AUTOR:  Lídia García Romero
    /// DATA:   17/05/2021
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: primera versió on només es programa el so dels botons i el botó back.
    /// ----------------------------------------------------------------------------------
    /// </summary>
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void ReproduirSo(AudioSource so)
    {
        so.Play();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Inici");
    }
}
