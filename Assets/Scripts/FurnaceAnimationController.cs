using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceAnimationController : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeDown()
    {
        anim.Play("FadeDown");
    }
    public void FadeUp()
    {
        anim.Play("FadeUp");

    }

}
