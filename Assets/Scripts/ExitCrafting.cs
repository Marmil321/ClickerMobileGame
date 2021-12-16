using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCrafting : MonoBehaviour
{
    public Animator anim;
    private void Start()
    {
        
    }
    public void Exit()
    {
        this.GetComponent<Canvas>().enabled = false;
    }
}
