using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCrafting : MonoBehaviour
{
    public GameObject close;

    public void Exit()
    {
        this.GetComponent<Canvas>().enabled = false;
    }
}
