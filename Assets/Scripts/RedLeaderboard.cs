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

public class RedLeaderboard : MonoBehaviour
{

    [SerializeField]
    public static RedLeaderboard instance;

    public TextMeshProUGUI resultado;
    public TextMeshProUGUI resultadoF;

    //Los datos de entrada
    public TMP_InputField textoUsuario;

    public string regresaUsuario()
    {
        instance = this;
        string usuario = textoUsuario.text;
        return usuario;
    }


    //Enviar los datos al servidor(click del boton)
    public void EnviarDatos()
    {
        StartCoroutine(SubirDatos());
    }

    private IEnumerator SubirDatos()
    {
        //Recuperar los datos
        //string usuario = textoUsuario.text;


        //Crear un objeto con los datos
        WWWForm forma = new WWWForm();
        //forma.AddField("nombreUsuario", usuario);





        UnityWebRequest request = UnityWebRequest.Post("http://localhost/CapturaDatos/LeaderboardDM.php", forma);
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


    //Enviar los datos al servidor(click del boton)
    public void EnviarDatosF()
    {
        StartCoroutine(SubirDatosF());
    }

    private IEnumerator SubirDatosF()
    {
        //Recuperar los datos
        //string usuario = textoUsuario.text;


        //Crear un objeto con los datos
        WWWForm forma = new WWWForm();
        //forma.AddField("nombreUsuario", usuario);


        UnityWebRequest request = UnityWebRequest.Post("http://localhost/CapturaDatos/LeaderboardF.php", forma);
        yield return request.SendWebRequest();
        //....despues de cierto tiempo
        if (request.result == UnityWebRequest.Result.Success)
        {
            string texto = request.downloadHandler.text;
            resultadoF.text = texto;
        }
        else
        {
            resultadoF.text = "Error: " + request.ToString();
        }


    }
}

