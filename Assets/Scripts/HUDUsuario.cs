using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*Autor: Maximiliano Benítez Ahumada - A01752791
 * Manipular las imágenes de vida para que representen la salud del personaje*/

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
