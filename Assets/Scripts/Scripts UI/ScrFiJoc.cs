using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrFiJoc : MonoBehaviour
{
    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script utilitzat per la programació de la pantalla de fi de joc
    /// AUTOR:  Lidia García Romero
    /// DATA:   19/05/2021
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: es crea l'script i funciona perfectament
    /// ----------------------------------------------------------------------------------
    /// </summary>

    [SerializeField] Canvas canvasFi;
    [SerializeField] AudioSource musica;
    [SerializeField] Text textFi;
    [SerializeField] GameObject player1, player2;
    string[] nivells = new string[3] { "Nivell1", "Nivell2", "Nivell3" };

    void Start()
    {
        canvasFi.gameObject.SetActive(false);
    }

    void Update()
    {
        if(player1.GetComponent<ScrPlayer>().vida <= 0) //guanya el player 2
        {
            Time.timeScale = 0;
            textFi.text = (ScrControlGame.nomPlayer2 + " WINS!");
            canvasFi.gameObject.SetActive(true);
        }

        if (player2.GetComponent<ScrPlayer>().vida <= 0) //guanya el player 1
        {
            Time.timeScale = 0;
            textFi.text = (ScrControlGame.nomPlayer1 + " WINS!");
            canvasFi.gameObject.SetActive(true);
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

    public void CarregarNivell()
    {
        Time.timeScale = 1;
        musica.Stop();

        SceneManager.LoadScene(nivells[0]);
    }
}
