using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
    /*Autores: Equipo 1
     * Paulo Ogando Gulias
     * Este codigo es el que indica que tecla se debe presionar por tambor, asi como en cual 
     * collider se presiono la tecla, porque dependiendo del collider se da cierto puntaje
     */

    private bool Activator = false;
    private bool _NiceHit = false;
    private bool _NormalHit = false;
    private bool _WasHit = false;

    public KeyCode Key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            print("Funciono");
            if (Activator)
            {
                if (_NiceHit)
                {
                    PerfectHit();
                }
                if (_NormalHit)
                {
                    NormalHit();
                }
            }
        }
    }

    //Indica que el golpe debe dar 200 puntos en el LevelManager
    public void PerfectHit()
    {
        LevelManager.instance.NiceHit();
        _WasHit = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

    }
    
    //Indica que el golpe debe dar 100 puntos en el LevelManager
    public void NormalHit()
    {
        LevelManager.instance.Hit();
        _WasHit = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

    }

    //Indica que se presiono la tecla, por lo que debe reiniciar los valores booleanos
    public void WasHit()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.SetActive(false);
        _WasHit = false;
        _NiceHit = false;
        _NormalHit = false;
    }

    //Indica que no se presiono la tecla, por lo que no debe dar puntos y debe restar 100 
    public void WasNotHit()
    {
        LevelManager.instance.Fail();
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.SetActive(false);
        _WasHit = false;
        _NiceHit = false;
        _NormalHit = false;
    }

    //Maneja los 3 colliders, asi como el del circulo que se hace pequeño
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            Activator = true;
            _NiceHit = true;
            _NormalHit = false;
        }

        if (collision.tag == "NormalHit")
        {
            Activator = true;
            _NormalHit = true;
            _NiceHit = false;
        }
        if (collision.tag == "Destroyer")
        {
            if (_WasHit)
            {
                WasHit();
            }
            else
            {
                WasNotHit();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NormalHit")
        {
            Activator = false;
        }
        
    }
}
