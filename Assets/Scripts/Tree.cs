using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public Animator anim;
    public UIScript ui;

    private void Start()
    {
        anim = GetComponent<Animator>();
        ui = FindObjectOfType<UIScript>();
    }

    public void FadeOut()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("TreeFadeLeft"))
        {
            anim.Play("TreeFadeLeft");
        }        
    }
    public void FadeInn()
    {
        anim.Play("TreeFadeRight");
    }
    public void FadeDown()
    {
        anim.Play("TreeFadeDown");
    }
    public void FadeUp()
    {
        anim.Play("TreeFadeUp");
    }
   
}
