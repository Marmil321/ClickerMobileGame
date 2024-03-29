using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundManager : MonoBehaviour
{
    public GameObject[] background;

    public StateManager state;

    private void Start()
    {
        state = FindObjectOfType<StateManager>();
    }

    private void Update()
    {
        //Change Backgorund
        switch (state.GetState())
        {
            case "tree":
                background[0].SetActive(true);
                background[1].SetActive(false);
                break;
            case "stone":
                background[1].SetActive(true);
                background[0].SetActive(false);
                break;
        }
    }
}
