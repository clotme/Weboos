using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrMenuInicial : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per la programació que gesyiona el menú principal del joc.
    /// AUTOR:  Lídia García Romero
    /// DATA:   17/05/2021
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: Creació dels controls del menú. Únicament es programen els sons dels 
    ///             botons i el botó start.
    /// ----------------------------------------------------------------------------------
    /// </summary>


    [SerializeField] public AudioSource musicaFons;
    bool musicaIsPlaying = false;

    void Start()
    {
        DontDestroyOnLoad(musicaFons);
    }

    
    void Update()
    {
        if (musicaIsPlaying == false) //per evitar que quant tornem a l'escena de menú, la música es solapi a ella mateixa
        {
            musicaFons.Play();
            musicaIsPlaying = true;
        }   
    }

    public void ReproduirSo(AudioSource so)
    {
        so.Play();
    }

    public void StartSeleccio()
    {        
        SceneManager.LoadScene("Seleccio");
    }
}
