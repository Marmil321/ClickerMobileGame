using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryText : MonoBehaviour
{
    public Text woodText, stoneText, ironText, coalText, stickText;
    public int testint;
    public TextMeshProUGUI currentAmount;

    public InventoryManager inv;
    public UIScript ui;
    private WorldSpaceCameraScript oreStage;

    private void Start()
    {
        inv = FindObjectOfType<InventoryManager>();
        ui = FindObjectOfType<UIScript>();
        oreStage = FindObjectOfType<WorldSpaceCameraScript>();
    }

    private void Update()
    {
        switch (ui.i)
        {
            case 0:
                switch (ui.page)
                {
                    case 0:
                        currentAmount.text = ShortenNumber(inv.wood);
                        break;
                    case 1:
                        currentAmount.text = ShortenNumber(inv.stone);
                        break;
                }
                break;
            case 1:
                switch (oreStage.stage)
                {
                    case 0:
                        currentAmount.text = ShortenNumber(inv.bronzeOre);
                        break;
                    case 1:
                        currentAmount.text = ShortenNumber(inv.ironOre);
                        break;
                }             
                break;
        }
        

        woodText.text = ShortenNumber(inv.wood);
        stoneText.text = ShortenNumber(inv.stone);
        ironText.text = ShortenNumber(inv.bronze);
        coalText.text = ShortenNumber(inv.coal);
        stickText.text = ShortenNumber(inv.stick);

    }
    public string ShortenNumber(double value)
    {
        if(value > 999 && value < 999999)
        {
            return (value / 1000).ToString("0.0") + "k";
        }else if (value > 999999 && value < 999999999)
        {
            return (value / 1000000).ToString("0.0") + "m";
        }else if (value > 999999999)
        {
            return "too much";
        }

        return value.ToString();
    }
}
