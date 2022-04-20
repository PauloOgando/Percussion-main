using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botón : MonoBehaviour
{
    public GameObject camara;


    public void LogIn()            // Cambiar a escena de Menu Principal
    {
        SceneManager.LoadScene("Menu_Principal");
    }

    public void Register()            // Cambiar a escena de Registro
    {
        SceneManager.LoadScene("Register");
    }

    public void BackInicio()            // Volver a escena de Inicio
    {
        SceneManager.LoadScene("Inicio");
    }


    public void Jugar()            // Cambiar a escena de Niveles
    {
        SceneManager.LoadScene("Paises");
    }

    public void Siguiente()  // Cambia elección de nivel
    {
        Cámara.instance.moverDerecha();
    }

    public void Prev()  // Cambia elección de nivel
    {
        Cámara.instance.moverIzquierda();
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
        SceneManager.LoadScene("Easy_Nigeria");
    }

    public void Drummer_Nigeria()            // Entrar a nivel difícil Nigeria
    {
        SceneManager.LoadScene("Drummer_Nigeria");
    }


    public void Settings()       // Cambiar a escena de Settings
    {
        SceneManager.LoadScene("Settings");
    }



}
