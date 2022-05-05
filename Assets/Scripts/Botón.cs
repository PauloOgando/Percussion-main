using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botón : MonoBehaviour
{
    /*
     * Autores: Equipo 1
     * Paulo Ogando Gulias
     * Eduardo Joel Cortez
     * Maximiliano Benitez Ahumada
     * Se encarga de cambiar las escenas del LogIn 
     */

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


}
