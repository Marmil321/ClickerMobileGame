using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManger : MonoBehaviour
{
    public StateManager state;
    public RequirementList requirementList;

    public int[] upgradeAmounts;
    public TMP_Text upgradeAmountText;

    public List<int> reqs = new List<int>();
    //tree      0
    //stone     1
    //iron      2
    //sticks    3

    private void Start()
    {
        state = GetComponent<StateManager>();
        requirementList = GetComponent<RequirementList>();

        if (PlayerPrefs.GetInt("TreeLevel") == 0)
        {
            upgradeAmounts[0] = PlayerPrefs.GetInt("TreeLevel") + 1;
        }else
        {
            upgradeAmounts[0] = PlayerPrefs.GetInt("TreeLevel");
        }
        if (PlayerPrefs.GetInt("StoneLevel") == 0)
        {
            upgradeAmounts[1] = PlayerPrefs.GetInt("StoneLevel") + 1;
        }
        else
        {
            upgradeAmounts[1] = PlayerPrefs.GetInt("StoneLevel");
        }
        if (PlayerPrefs.GetInt("FurnaceLevel") == 0)
        {
            upgradeAmounts[2] = PlayerPrefs.GetInt("FurnaceLevel") + 1;
        }
        else
        {
            upgradeAmounts[2] = PlayerPrefs.GetInt("FurnaceLevel");
        }
    }

    private void Update()
    {
        GetRequirements();

        upgradeAmountText.text = "Level: " + GetLevel().ToString();

        PlayerPrefs.SetInt("TreeLevel", upgradeAmounts[0]);
        PlayerPrefs.SetInt("StoneLevel", upgradeAmounts[1]);
        PlayerPrefs.SetInt("FurnaceLevel", upgradeAmounts[2]);

    }
    public void GetRequirements()
    {
        switch (state.activeState)
        {
            default:
            case "tree":     requirementList.Wood(); break; 
            case "stone":    requirementList.Stone(); break;
            case "furnace":  requirementList.Furnace(); break;
        }
    } 

    public int GetLevel()
    {
        int i = 0;

        switch (state.activeState)
        {
            case "tree":
                i = 0;
                break;
            case "stone":
                i = 1;
                break;
            case "furnace":
                i = 2;
                break;
        }

        return upgradeAmounts[i];
    }
}
