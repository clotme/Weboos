using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrPausa : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per programar la pausa del joc i els seus botons.
    /// AUTOR:  Lidia Garcia Romero
    /// DATA:   23/06/2021
    /// VERSIÓ: 1.2
    /// CONTROL DE VERSIONS
    ///         1.0: Es crea l'Script més sencill.
    ///             1.1: Es creen més funcions pels botons
    ///             1.2: Es modifica el boto d'instruccions i tornar al menu
    /// ----------------------------------------------------------------------------------
    /// </summary>

    [SerializeField] AudioSource musica;
    [SerializeField] Canvas canvasInstruccions;
    
    void Start()
    {
        gameObject.SetActive(false); //el joc començarà no pausat
        canvasInstruccions.gameObject.SetActive(false);

        musica = GetComponent<AudioSource>();
    }

    public void SetPausa(bool estat)
    {
        if (estat)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        else
        {           
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }

    public void ReproduirSo(AudioSource so)
    {
        so.Play();
    }

    public void TornarMenu()
    {
        Time.timeScale = 1;
        musica.Stop();

        SceneManager.LoadScene("Inici");
    }

    public void setInstruccions(bool estat)
    {
        if (estat)
        {
            canvasInstruccions.gameObject.SetActive(true);
        }
        else
        {
            canvasInstruccions.gameObject.SetActive(false);

        }
    }
}
