using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManger : MonoBehaviour
{
    public StateManager state;

    public int[] upgradeAmounts;
    public Text upgradeAmountText;

    public int treeReq, stoneReq, ironReq;

    private void Start()
    {
        state = GetComponent<StateManager>();

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
        upgradeAmountText.text = "Level: " + GetLevel().ToString();

        PlayerPrefs.SetInt("TreeLevel", upgradeAmounts[0]);
        PlayerPrefs.SetInt("StoneLevel", upgradeAmounts[1]);
        PlayerPrefs.SetInt("FurnaceLevel", upgradeAmounts[2]);

        treeReq = upgradeAmounts[0] * (100 * upgradeAmounts[0]);
        stoneReq = upgradeAmounts[1] * (100 * upgradeAmounts[1]);
        ironReq = upgradeAmounts[2] * (100 * upgradeAmounts[2]);
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
