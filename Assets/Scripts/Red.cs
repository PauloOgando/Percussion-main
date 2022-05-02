using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System;

/*Autores: Paulo Ogando
 *          Christian Parrish
 *          Eduardo Cortez
 *          Maximiliano Ben?tez
 *          Jorge Blanco */

public class Red : MonoBehaviour
{

    [SerializeField]
    public static Red instance;

    public TextMeshProUGUI resultado;

    //Los datos de entrada
    public TMP_InputField textoUsuario;
    public TMP_InputField textoContrasena;
    public TMP_InputField textoCumple;
    public TMP_InputField textoEmail;
    public TMP_InputField textoSexo;

    public string regresaUsuario()
    {
        instance = this;
        string usuario = textoUsuario.text;
        return usuario;
    }

    public string regresaContrasena()
    {
        instance = this;
        string contrasena = textoContrasena.text;
        return contrasena;
    }

    public string regresaCumple()
    {
        instance = this;
        string cumple = textoCumple.text;
        return cumple;
    }

    public string regresaEmail()
    {
        instance = this;
        string email = textoEmail.text;
        return email;
    }

    public string regresaSexo()
    {
        instance = this;
        string sexo = textoSexo.text;
        return sexo;
    }

    //Enviar los datos al servidor(click del boton)
    public void EnviarDatos()
    {
        StartCoroutine(SubirDatos());
    }

    private IEnumerator SubirDatos()
    {
        //Recuperar los datos
        string usuario = textoUsuario.text;
        string contrasena = textoContrasena.text;
        string cumple = textoCumple.text;
        string email = textoEmail.text;
        string sexo = textoSexo.text;

        //Crear un objeto con los datos
        WWWForm forma = new WWWForm();
        forma.AddField("nombreUsuario", usuario);
        forma.AddField("contrasena", contrasena);
        forma.AddField("cumple", cumple);
        forma.AddField("email", email);
        forma.AddField("sexo", sexo);

        /*http ://143.198.157.129/CapturaDatos/recibeDatosNube.php */
        //https ://pwt-beta.000webhostapp.com/CapturaDatos/recibeDatosNube.php




        UnityWebRequest request = UnityWebRequest.Post("http://143.198.157.129/CapturaDatos/recibeDatosNube.php", forma);
        yield return request.SendWebRequest();
        //....despues de cierto tiempo
        if (request.result == UnityWebRequest.Result.Success)
        {
            string texto = request.downloadHandler.text;
            resultado.text = texto;
        }
        else
        {
            resultado.text = "Error: " + request.ToString();
        }
    }

    
}


