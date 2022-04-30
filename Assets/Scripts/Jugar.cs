using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugar : MonoBehaviour
{
    public static Jugar instance;

    private float velocidadCirculos = .7f;
    private int[] VectorCirculos = {0, 1, 2, 3, 4, 5};

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    /*private bool IniciarCorrutina = false;*/

    void Start()
    {
        Time.timeScale = LevelManager.instance.isPaused ? 0 : 1;
    }
    

    void Update()
    {
        /*
        if (LevelManager.instance.StartLevel)
        {
            IniciarCorrutina = true;
            if (IniciarCorrutina)
            {
                print("Iniciando Corrutina");
                StartCoroutine(MostrarCirculos());
                
            }
        }
        */
    }

    public IEnumerator MostrarCirculos()
    {
        foreach (int i in VectorCirculos)
        {
            if (i == 5)
            {
                yield return new WaitForSeconds(velocidadCirculos);
            }
            else
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitForSeconds(velocidadCirculos);
            }
        }
        yield return new WaitForSeconds(2);
        LevelManager.instance.DeployEndText(); //Checarlo con el profe
        yield return new WaitForSeconds(3);
        FinishLevel();

    }

    public void FinishLevel()
    {
        /*LevelManager.instance.Song.Stop();*/
        LevelManager.instance.DeployEndPanel();
    }




}
