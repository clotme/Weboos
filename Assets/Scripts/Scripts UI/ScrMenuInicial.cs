using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrMenuInicial : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per la programació que gesyiona el menú principal del joc.
    /// AUTOR:  Lídia García Romero
    /// DATA:   17/05/2021
    /// VERSIÓ: 2.0
    /// CONTROL DE VERSIONS
    ///         1.0: Creació dels controls del menú. Únicament es programen els sons dels 
    ///             botons i el botó start
    ///         2.0: Creació dels botons de informació i instruccions amb les seves programacions
    /// ----------------------------------------------------------------------------------
    /// </summary>


    [SerializeField] Canvas CanvasInfo, canvasInstruccions;

    private void Start()
    {
        CanvasInfo.gameObject.SetActive(false);
        canvasInstruccions.gameObject.SetActive(false);
    }

    public void ReproduirSo(AudioSource so)
    {
        so.Play();
    }

    public void StartSeleccio()
    {        
        SceneManager.LoadScene("Seleccio");
    }

    public void SortirJoc()
    {
        Application.Quit();
    }

    public void AnarWeb()
    {
        Application.OpenURL("https://www.emav.com/");
    }

    public void SetInformacio(bool estat)
    {
        if (estat)
        {
            CanvasInfo.gameObject.SetActive(true);
        }

        else
        {
            CanvasInfo.gameObject.SetActive(false);
        }
    }

    public void SetInstruccions(bool estat)
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
