using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void FadeInn()
    {
        anim.Play("RockEnableAnim");
    }
    public void FadeOut()
    {
        anim.Play("StoneFadeOut");

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
