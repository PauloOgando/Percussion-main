using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*Autor: Equipo 1
 * Paulo Ogando Gulias
 * Maximiliano Benitez Ahumada
 * Christian Parrish
 * Cambia el nombre de usuario al hacer logIn en el menu principal
 */

public class HUDUsuario : MonoBehaviour
{
    public static HUDUsuario instance;


    public TextMeshProUGUI txtUsuario;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        //Recupera las monedas almacenadas
        string usuario = PlayerPrefs.GetString("Usuario", "NULL");
        RedLogIn.instance.usuarioLI = usuario;
        ActualizarNombreUsuario();
    }

   
 

    public void ActualizarNombreUsuario() {  
        string usuario = RedLogIn.instance.usuarioLI;
        txtUsuario.text = usuario;
    }
}
