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

    private void Start()
    {
        inv = FindObjectOfType<InventoryManager>();
        ui = FindObjectOfType<UIScript>();
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
                currentAmount.text = ShortenNumber(inv.iron);
                break;
        }
        

        woodText.text = ShortenNumber(inv.wood);
        stoneText.text = ShortenNumber(inv.stone);
        ironText.text = ShortenNumber(inv.iron);
        coalText.text = ShortenNumber(inv.coal);
        stickText.text = ShortenNumber(inv.stick);

    }
    public string ShortenNumber(double value)
    {
        if(value > 999 && value < 999999)
        {
            return (value / 1000).ToString() + "k";
        }else if (value > 999999 && value < 999999999)
        {
            return (value / 1000000).ToString() + "m";
        }else if (value > 999999999)
        {
            return "too much";
        }

        return value.ToString();
    }
}
