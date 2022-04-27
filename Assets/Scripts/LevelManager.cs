using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public AudioSource Song;

    public bool StartLevel = false;

    public GameObject tambores;

    public GameObject circulos;

    public GameObject btn;

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
        if (!StartLevel)
        {
            print("StarLevel = true");
            /*StartLevel = true;*/
            DialogManager.instance.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            
        }
    }

    public void Jugar()
    {
        if (!StartLevel)
        {
            StartLevel = true;
            DialogManager.instance.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            circulos.SetActive(true);
        }
    }
}
