using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
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
    public void PlayAnimation()
    {
        animator.SetBool("true", true);
    }

    public void StopAnimation()
    {
        animator.SetBool("true", false);
    }

}
