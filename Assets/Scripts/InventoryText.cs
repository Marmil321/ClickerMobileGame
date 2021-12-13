using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryText : MonoBehaviour
{
    public Text woodText, stoneText, ironText, coalText, stickText;
    public InventoryManager inv;
    public int testint;

    private void Start()
    {
        inv = FindObjectOfType<InventoryManager>();
    }

    private void Update()
    {
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
