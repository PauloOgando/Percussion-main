using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMasterAnimation : MonoBehaviour
{
    /*
     * Autores: Equipo 1
     * Paulo Ogando Gulias
     * Christian Parrish Gutierrez
     * Variacion del codigo ChangeAnimation para el segundo personaje de la escena, se creo
     * porque teniendo solo un script, la animacion no corria. 
     */
    public static ChangeMasterAnimation instance;

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
    public void PlayAnimation()
    {
        animator.SetBool("Play", true);
    }

    public void StopAnimation()
    {
        animator.SetBool("Play", false);
    }
}
