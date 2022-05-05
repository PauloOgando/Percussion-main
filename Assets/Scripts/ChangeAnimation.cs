using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    /*
     * Autores: Equipo 1
     * Paulo Ogando Gulias
     * Christian Parrish Gutierrez
     * Este codigo se encarga de arrancar las animaciones de los personajes de las escena
     */

    public static ChangeAnimation instance;

    private Animator animator;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    //Arranca la animacion en el momento indicado
    public void PlayAnimation()
    {
        animator.SetBool("true", true);
    }

    //Para la animacion en el momento indicado
    public void StopAnimation()
    {
        animator.SetBool("true", false);
    }

}
