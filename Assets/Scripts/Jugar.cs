using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugar : MonoBehaviour
{

    /*
     * Autores: Equipo 1
     * Paulo Ogando Gulias
     * Christian Parrish Gutierrez
     * Este codigo se encarga de arrancar la corrutina en la que se basa el juego, es decir
     * de la aparicion de los 5 circulos
     * */

    public static Jugar instance;

    public float velocidadCirculos = 1.4f; //Es el ritmo con el que aparecen los circulos

    //Es el numero de circulo que aparece, en ese orden
    public int[] VectorCirculos = {0, 1, 2, 4, 3, 0, 1, 2, 4, 3, 0, 1, 2, 4, 3, 0, 1, 2, 4, 3, 0, 1, 2, 4, 3, 0, 1, 2, 4, 3,
                                    0, 1, 2, 4, 3, 0, 1, 2, 4, 3, 0, 1, 2}; 
    
    //Cuanto tarda el nivel en empezar despues de darle Play
    public float WaitTime = 0;

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

    }

    /*Corrutina para la aparicion de los circulos, la cual arranca la animacion de los personajes
     * y comienza a activar sefun el vector creado arriba los distintos circulos a traves del metodo
     * GetChild. Al final, despliega el texto final del Maestro y termina el nivel
     */
    public IEnumerator MostrarCirculos()
    {
        yield return new WaitForSeconds(WaitTime);
        ChangeAnimation.instance.PlayAnimation();
        ChangeMasterAnimation.instance.PlayAnimation();
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
        LevelManager.instance.DeployEndTextJapanEasy(); //Checarlo con el profe
        yield return new WaitForSeconds(3);
        FinishLevel();

    }

    //Metodo que terminal el nivel parando la cancion, las animaciones y desplegando el panel final
    public void FinishLevel()
    {
        LevelManager.instance.Song.Stop();
        ChangeAnimation.instance.StopAnimation();
        ChangeMasterAnimation.instance.StopAnimation();
        LevelManager.instance.DeployEndPanel();
    }




}
