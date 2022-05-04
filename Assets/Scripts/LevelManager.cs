using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
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

    public void HowTo()
    {
        DialogManager.instance.gameObject.transform.GetChild(3).gameObject.SetActive(false); /*Boton How To*/
        DialogManager.instance.gameObject.transform.GetChild(5).gameObject.SetActive(true); /* Panel How To Play*/
    }
    public void HowTo2()
    {
        DialogManager.instance.gameObject.transform.GetChild(5).gameObject.SetActive(false); /* Panel How To Play*/
        DialogManager.instance.gameObject.transform.GetChild(11).gameObject.SetActive(true);
    }

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

    public void DeployEndPanel()
    {
        DialogManager.instance.gameObject.transform.GetChild(8).gameObject.SetActive(false);
        DialogManager.instance.gameObject.transform.GetChild(9).gameObject.SetActive(true);
        FinalScore.text = "Your Final Score Was: " + Score.ToString();
    }

    public void NiceHit()
    {
        Score += _NiceHit;
        ScoreText.text = Score.ToString();
    }
    public void Hit()
    {
        Score += _Hit;
        ScoreText.text = Score.ToString();
    }

    public void Fail()
    {
        Score -= _Hit;
        ScoreText.text = Score.ToString();
        StartCoroutine(ShowFailText());

    }

    public IEnumerator ShowFailText()
    {
        FailText.text = "Fail!";
        DialogManager.instance.gameObject.transform.GetChild(7).gameObject.SetActive(true);
        yield return new WaitForSeconds(.2f);
        DialogManager.instance.gameObject.transform.GetChild(7).gameObject.SetActive(false);
    }

    public void EndLevel()
    {
        //Aqui iria el registro de la hora final 
        //Registrar puntuacion final tambien

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