using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public string activeState;
    private string tree = "tree", stone = "stone", furnace = "furnace";

    public UIScript ui;

    public Text upgradeReqs;

    private void Start()
    {
        ui = FindObjectOfType<UIScript>(); 
    }

    private void Update()
    {
        activeState = GetState();
        upgradeReqs.text = activeState;
    }
    public string GetState()
    {
        if (ui.page == 0 && ui.i == 0)
        {
            return tree;
        } else if (ui.page == 1 && ui.i == 0)
        {
            return stone;
        }
        else if (ui.i == 1)
        {
            return furnace;
        }
        else
        {
            return "ERROR";
        }
        
    }
}
