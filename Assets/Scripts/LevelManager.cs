using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public AudioSource Song;

    public int Score = 0;
    private int _NiceHit = 200;
    private int _Hit = 100;

    public TextMeshProUGUI ScoreText;

    public bool StartLevel = false;

    public GameObject tambores;
    public GameObject circulos;
    public GameObject Scorer;
    public GameObject HowToPlay;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jugar()
    {
        if (HowToPlay.activeInHierarchy == true)
        {
            HowToPlay.SetActive(false);
        }
        StartLevel = true;
        DialogManager.instance.gameObject.transform.GetChild(2).gameObject.SetActive(false); /*Boton Play*/
        DialogManager.instance.gameObject.transform.GetChild(3).gameObject.SetActive(false);
        Scorer.SetActive(true);
        StartCoroutine(circulos.GetComponent<Jugar>().MostrarCirculos());
    }

    public void HowTo()
    {
        DialogManager.instance.gameObject.transform.GetChild(3).gameObject.SetActive(false); /*Boton How To*/
        DialogManager.instance.gameObject.transform.GetChild(5).gameObject.SetActive(true); /* Panel How To Play*/
    }

    /*public void End()
    {

    }*/

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
}
