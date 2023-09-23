using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public static Paddle instance;
    Animator animator;
    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    public void MovePaddle()
    {
        if(animator.GetBool("isPaddle")) 
        {
            return;
        }
        animator.SetBool("isPaddle",true);
        animator.SetTrigger("Paddle");
    }

    public void StopPaddle()
    {
        animator.SetBool("isPaddle",false);
    }
}
