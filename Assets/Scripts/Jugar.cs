using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugar : MonoBehaviour
{
    public static Jugar instance;

    public float velocidadCirculos = 1;
    public int[] VectorCirculos = {0, 1, 2, 3, 4, 5, 0, 1, 2, 3, 4, 0, 1, 2, 3, 4, 0, 1, 2, 3, 4};

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    /*private bool IniciarCorrutina = false;*/

    void Start()
    {
        
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
                print("Aqui ando");
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitForSeconds(velocidadCirculos);
            }
        }
        yield return new WaitForSeconds(2);
    }



}
