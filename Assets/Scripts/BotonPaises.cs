using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonPaises : MonoBehaviour
{


    public void IrMenu()            // Regresar al Menu
    {
        SceneManager.LoadScene("Menu_Principal");
    }

    public void IrUSA()            // Cambiar a escena de USA
    {
        SceneManager.LoadScene("Usa_Pantalla");
    }

    public void IrJapon()          // Cambiar a escena de Japon
    {
        SceneManager.LoadScene("Japon_Pantalla");
    }

    public void IrNiger()            // Cambiar a escena de Nigeria
    {
        SceneManager.LoadScene("Nigeria_Pantalla");
    }

    public void Easy_Japon()            // Entrar a nivel fácil Japón
    {

        SceneManager.LoadScene("Easy_Japon");

    }

    public void Drummer_Japon()            // Entrar a nivel difícil Japón
    {
        SceneManager.LoadScene("Drummer_Japon");
    }


    public void Easy_USA()            // Entrar a nivel fácil USA
    {
        SceneManager.LoadScene("Easy_USA");
    }

    public void Drummer_USA()            // Entrar a nivel difícil USA
    {
        SceneManager.LoadScene("Drummer_USA");
    }

    public void Easy_Nigeria()            // Entrar a nivel fácil Nigeria
    {
        SceneManager.LoadScene("Easy_Africa");
    }

    public void Drummer_Nigeria()            // Entrar a nivel difícil Nigeria
    {
        SceneManager.LoadScene("Drummer_Africa");
    }

    public void Leaderboard()            // Ir a escena de Leaderboard
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void PAS()            // Ir a escena de About PAS
    {
        SceneManager.LoadScene("PAS");
    }



}
