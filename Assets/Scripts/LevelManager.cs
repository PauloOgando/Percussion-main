using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    /* Autores: Equipo 1
     * Paulo Ogando Gulias
     * Eduardo Joel Cortez
     * Maximiliano Benitez Ahumada
     * Christian Parrish Gutierrez
     * Jorge Isidro Blanco 
     * Este script es el que maneja las variables, desplegables y escenas dentro del nivel, 
     * asi como tambien se encarga de subir los datos a la base, terminar el nivel y llevar
     * el conteo de puntos
     */
    public static LevelManager instance;

    public AudioSource Song;

    private int Score = 0;
    public bool isPaused = false;

    private int _NiceHit = 200;
    private int _Hit = 100;

    public string horaInicioS;
    public string horaFinS;

    public int nivelS;
    public int dificultad;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI FailText;
    public TextMeshProUGUI EndText;
    public TextMeshProUGUI FinalScore;

    private TextMeshProUGUI resultado;

    /*public bool StartLevel = false;*/

    public GameObject tambores;
    public GameObject circulos;
    public GameObject Scorer;
    public GameObject HowToPlay;
    public GameObject HowToPlay2;
    public GameObject PausePanel;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        horaInicioS = System.DateTime.Now.Hour.ToString("00") + ":" + System.DateTime.Now.Minute.ToString("00") + ":" + System.DateTime.Now.Second.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    //Es el metodo que arranca el nivel iniciando las corrutinas. 
    public void Jugar()
    {
        if (HowToPlay.activeInHierarchy == true)
        {
            HowToPlay.SetActive(false);
        }
        if (HowToPlay2.activeInHierarchy == true)
        {
            HowToPlay2.SetActive(false);
        }

        LevelManager.instance.Song.Play();
        DialogManager.instance.gameObject.transform.GetChild(2).gameObject.SetActive(false); /*Boton Play*/
        DialogManager.instance.gameObject.transform.GetChild(3).gameObject.SetActive(false);
        Scorer.SetActive(true);
        StartCoroutine(circulos.GetComponent<Jugar>().MostrarCirculos());

    }

    //Proporciona un panel de pausa al nivel
    public void Pause()
    {
        isPaused = !isPaused;
        PausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
        //Pause music of the level
        if (isPaused)
        {
            Song.Pause();
        }
        else
        {
            Song.Play();
        }
    }

    //Activa el panel de Como jugar dentro del nivel 
    public void HowTo()
    {
        DialogManager.instance.gameObject.transform.GetChild(3).gameObject.SetActive(false); /*Boton How To*/
        DialogManager.instance.gameObject.transform.GetChild(5).gameObject.SetActive(true); /* Panel How To Play*/
    }

    //Cambia el panel de Como jugar, ya que consta de 2 paneles
    public void HowTo2()
    {
        DialogManager.instance.gameObject.transform.GetChild(5).gameObject.SetActive(false); /* Panel How To Play*/
        DialogManager.instance.gameObject.transform.GetChild(11).gameObject.SetActive(true);
    }

    //Dependiendo de la puntuacion, despliega un texto distinto al final
    public void DeployEndText()
    {
        if (Score < 7500)
        {
            DialogManager.instance.gameObject.transform.GetChild(8).gameObject.SetActive(true);
            EndText.text = "You still need to learn a lot Michael, that was shameful";
        }
        if (Score > 7500 && Score < 12500)
        {
            DialogManager.instance.gameObject.transform.GetChild(8).gameObject.SetActive(true);
            EndText.text = "That was pretty good for you, but you are not at my level";
        }
        if (Score >= 12500)
        {
            DialogManager.instance.gameObject.transform.GetChild(8).gameObject.SetActive(true);
            EndText.text = "I did not expect you to be this good, that was marvelous";
        }
    }

    //Dependiendo de la puntuacion en el nivel facil de Japon, despliega un texto distinto al final
    public void DeployEndTextJapanEasy()
    {
        if (Score < 3500)
        {
            DialogManager.instance.gameObject.transform.GetChild(8).gameObject.SetActive(true);
            EndText.text = "You still need to learn a lot Michael, that was shameful";
        }
        if (Score > 3500 && Score < 6000)
        {
            DialogManager.instance.gameObject.transform.GetChild(8).gameObject.SetActive(true);
            EndText.text = "That was pretty good for you, but you are not at my level";
        }
        if (Score >= 6000)
        {
            DialogManager.instance.gameObject.transform.GetChild(8).gameObject.SetActive(true);
            EndText.text = "I did not expect you to be this good, that was marvelous";
        }
    }

    //Despliega el panel del final del nivel
    public void DeployEndPanel()
    {
        DialogManager.instance.gameObject.transform.GetChild(8).gameObject.SetActive(false);
        DialogManager.instance.gameObject.transform.GetChild(9).gameObject.SetActive(true);
        FinalScore.text = "Your Final Score Was: " + Score.ToString();
    }

    //Suma 200 puntos si el golpe fue perfecto 
    public void NiceHit()
    {
        Score += _NiceHit;
        ScoreText.text = Score.ToString();
    }

    //Suma 100 puntos si el golpe fue normal
    public void Hit()
    {
        Score += _Hit;
        ScoreText.text = Score.ToString();
    }

    //Resta 100 puntos si el usuario no aprieta la tecla a tiempo, y despliega el texto Fail!
    public void Fail()
    {
        Score -= _Hit;
        ScoreText.text = Score.ToString();
        StartCoroutine(ShowFailText());

    }

    //Corrutina que despliega el texto por .2 segundos
    public IEnumerator ShowFailText()
    {
        FailText.text = "Fail!";
        DialogManager.instance.gameObject.transform.GetChild(7).gameObject.SetActive(true);
        yield return new WaitForSeconds(.2f);
        DialogManager.instance.gameObject.transform.GetChild(7).gameObject.SetActive(false);
    }

    //Termina el nivel registrando la hora en la que se regresa al menu principal 
    public void EndLevel()
    {

        //Registro de la hora final 
        horaFinS = System.DateTime.Now.Hour.ToString("00") + ":" + System.DateTime.Now.Minute.ToString("00") + ":" + System.DateTime.Now.Second.ToString("00");

        EnviarDatos();

        SceneManager.LoadScene("Menu_Principal");
    }

    //Enviar los datos al servidor(click del boton)
    public void EnviarDatos()
    {
        StartCoroutine(SubirDatosF());
    }

    private IEnumerator SubirDatosF()
    {
        //Recuperar los datos

        int idNivelP = nivelS;
        string horaInicio = horaInicioS;
        string horaFin = horaFinS;
        int puntuacion = Score;

        string usuario = PlayerPrefs.GetString("Usuario", "NULL");
        RedLogIn.instance.usuarioLI = usuario;



        //Crear un objeto con los datos
        WWWForm forma = new WWWForm();
        forma.AddField("idNivelP", idNivelP);
        forma.AddField("nombreUsuario", usuario);
        forma.AddField("horaInicio", horaInicio);
        forma.AddField("horaFin", horaFin);
        forma.AddField("puntuacion", puntuacion);

        //http ://143.198.157.129/CapturaDatos/IniciaSesion.php
        //https ://pwt-beta.000webhostapp.com/CapturaDatos/IniciaSesion.php


        if (dificultad == 1)
        {
            UnityWebRequest request = UnityWebRequest.Post("http://143.198.157.129/CapturaDatos/SubeNivelesFacil.php", forma);
            yield return request.SendWebRequest();
            //....despues de cierto tiempo
        } else
        {
            UnityWebRequest request = UnityWebRequest.Post("http://143.198.157.129/CapturaDatos/SubeNivelesDM.php", forma);
            yield return request.SendWebRequest();
            //....despues de cierto tiempo
        }


    }


}