using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMasterAnimation : MonoBehaviour
{
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
